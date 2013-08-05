using System;
using System.Collections.Generic;
using System.Linq;
using TinyDungeon.Utils.Maps.MapObjects;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TinyDungeon.Utils.Maps
{
	static class MapReader
	{
		/// <summary>
		/// Takes a string of JSON formatted as version 1 Tiled data and returns a POCO Map container.
		/// </summary>
		/// <param name="jsonString">The JSON string. The string isn't validated in any way, so passing in broken JSON syntax will throw an exception.</param>
		/// <returns>A map container filled with all the relevant data.</returns>
		public static Map ReadJson(string jsonString)
		{
			Map _newMap = new Map();

			try
			{
				JObject _mapJson = JObject.Parse(jsonString);

				// This mapreader can only read version 1 of the Tiled format.
				// Any other version is considered invalid and will not be parsed.
				if (_mapJson["version"].ToString() != "1")
				{
					throw new Exception("The map parser can only read version 1 of the Tiled map format. This map is reportedly version " + _mapJson["version"].ToString() + ".");
				}

				// Width and height of the map (in tiles)
				_newMap.MapWidth = int.Parse(_mapJson["width"].ToString());
				_newMap.MapHeight = int.Parse(_mapJson["height"].ToString());

				// Width and height of each tile (in pixels)
				_newMap.TileWidth = int.Parse(_mapJson["tilewidth"].ToString());
				_newMap.TileHeight = int.Parse(_mapJson["tileheight"].ToString());

				// Parse misc. map info
				_newMap.MapOrientation = _mapJson["orientation"].ToString();

				// Parse the map's tile layers
				JArray _layersJson = JArray.Parse(_mapJson["layers"].ToString());
				foreach (dynamic _layer in _layersJson)
				{
					MapLayer _newLayer = new MapLayer();

					// Verify the layer is a tilelayer
					if (_layer["type"] == "tilelayer")
					{
						// Parse the layer's general info
						_newLayer.LayerWidth = int.Parse(_layer["width"].ToString());
						_newLayer.LayerHeight = int.Parse(_layer["height"].ToString());

						// Parse the layer's tiles
						JArray _tilesJson = JArray.Parse(_layer["data"].ToString());
						foreach (dynamic _tile in _tilesJson)
						{
							MapTile _newTile = new MapTile(int.Parse(_tile.ToString()));
							_newLayer.Tiles.Add(_newTile);
						}
					}

					_newLayer.LayerName = _layer.name.ToString();
					_newMap.MapLayers.Add(_newLayer);
				}

				// Parse the map's tileset data
				JArray _tilesetsJson = JArray.Parse(_mapJson["tilesets"].ToString());
				foreach (dynamic _tileset in _tilesetsJson)
				{
					MapTilesetData _newTileset = new MapTilesetData();

					// Numeric ID of first tile in this tileset
					_newTileset.FirstID = int.Parse(_tileset["firstgid"].ToString());

					// Tileset name and path
					_newTileset.TilesetName = _tileset["name"].ToString();
					_newTileset.TilesetPath = _tileset["image"].ToString();

					// Tileset width and height (full size of image, in pixels)
					_newTileset.TilesetWidth = int.Parse(_tileset["imagewidth"].ToString());
					_newTileset.TilesetHeight = int.Parse(_tileset["imageheight"].ToString());

					// Width and height of each tile (in pixels)
					_newTileset.TileWidth = int.Parse(_tileset["tilewidth"].ToString());
					_newTileset.TileHeight = int.Parse(_tileset["tileheight"].ToString());

					// Parse through tileproperties for additional data
					//TODO: So far this only supports "tiletype" data
					foreach (dynamic _tile in (JObject)_tileset["tileproperties"])
					{
						foreach (dynamic _tileProperty in _tile.Value)
						{
							switch ((string)_tileProperty.Name)
							{
								case "tiletype":
									ChangeTileType(
										int.Parse(_tile.Key) + 1,				// Tile numbering starts at 1
										_tileProperty.Value.ToString(),
										_newMap
									);
									break;

								default:
									break;
							}
						}
					}

					_newMap.TileSetData.Add(_newTileset);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("An error occured while reading the map :(\n" + ex.ToString());
			}

			return _newMap;
		}

		/// <summary>
		/// Verifies that a map object doesn't contain any errors.
		/// </summary>
		/// <param name="map">A map container object.</param>
		/// <returns>True or false, depending on the map's validity.</returns>
		public static Boolean verifyMap(Map map)
		{
			// This mapreader can only read orthogonal maps
			if (map.MapOrientation != "orthogonal")
			{
				return false;
			}

			// The width&height of the map should be the same as the width&height of each of the layers
			foreach (MapLayer _layer in map.MapLayers)
			{
				if (_layer.LayerWidth != map.MapWidth || _layer.LayerHeight != map.MapHeight)
				{
					return false;
				}
			}

			// The width & height (in pixels) of the tiles should be the same
			foreach (MapTilesetData _tileset in map.TileSetData)
			{
				if (_tileset.TileHeight != map.TileHeight || _tileset.TileWidth != map.TileWidth)
				{
					return false;
				}
			}

			// The number of tiles in each layer should be equal to that layer's (width * height)


			return true;
		}

		/// <summary>
		/// Searches through a map's tiles to assign them a tiletype.
		/// </summary>
		/// <param name="tileNumberToChange">The tile numbers that will be replaced with the new type.</param>
		/// <param name="newTileType">A string representing the new tiletype.</param>
		/// <param name="map">The map object to replace tiles from.</param>
		/// <returns></returns>
		public static int ChangeTileType(int tileNumberToChange, string newTileType, Map map)
		{
			Console.WriteLine("Changing tile#" + tileNumberToChange + " to " + newTileType);
			int _tilesChanged = 0;
			
			foreach (MapLayer _layer in map.MapLayers)
			{
				foreach (MapTile _tile in _layer.Tiles)
				{
					if (_tile.TileNumber == tileNumberToChange)
					{
						switch (newTileType)
						{
							case "empty":
								_tile.TileType = MapTileType.Empty;
								break;
							case "solid":
								_tile.TileType = MapTileType.Solid;
								break;

							default:
								_tile.TileType = MapTileType.Empty;
								break;
						}
						_tilesChanged++;
					}
				}
			}

			return _tilesChanged;
		}
	}
}
