using System;
using Json2map;
using Json2Map.MapObjects;
using Newtonsoft.Json.Linq;

namespace Json2Map
{
	public class MapReader
	{
		private MapConfig config;

		public MapReader(MapConfig config)
		{
			this.config = config;
		}

		/// <summary>
		/// Takes a string of JSON formatted as version 1 Tiled data and returns a POCO Map container.
		/// </summary>
		/// <param name="jsonString">The JSON string. The string isn't validated in any way, so passing in broken JSON syntax will throw an exception.</param>
		/// <returns>A map container filled with all the relevant data.</returns>
		public Map ReadJson(string jsonString)
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
				for (int _layerIndex = 0; _layerIndex < _layersJson.Count; _layerIndex++)
				{
					dynamic _layer = _layersJson[_layerIndex];

					// Handle regular 'ol tilelayers
					if (_layer["type"] == "tilelayer")
					{
						MapTileLayer _newLayer = new MapTileLayer();

						// Parse the layer's general info
						_newLayer.LayerName = _layer.name.ToString();
						_newLayer.LayerWidth = int.Parse(_layer["width"].ToString());
						_newLayer.LayerHeight = int.Parse(_layer["height"].ToString());
						_newLayer.LayerVisibility = bool.Parse(_layer["visible"].ToString());

						// Parse the layer's tiles
						JArray _tilesJson = JArray.Parse(_layer["data"].ToString());
						foreach (dynamic _tile in _tilesJson)
						{
							MapTile _newTile = new MapTile(int.Parse(_tile.ToString()));
							_newLayer.Tiles.Add(_newTile);
						}

						// Figure out the layer's depth
						float _layerStepAmount = (config.MapLayers_Max - config.MapLayers_Min) / (_layersJson.Count + 1);
						_newLayer.LayerDepth =
							config.MapLayers_Min
							+ (_layerStepAmount * (_layerIndex + 1));

						// Handle a specific tilelayer that defines a relative LayerDepth for GameObjects
						if (_layer["name"].ToString() == "Objects")
						{
							_newMap.ObjectLayer = _newLayer;
						}

						_newMap.MapLayers.Add(_newLayer);
					}
					// Handle a specific objectlayer that defines "regions" for starting locations, control groups, etc.
					else if (_layer["type"] == "objectgroup" && _layer["name"].ToString() == "Regions")
					{
						JArray _objectsJson = JArray.Parse(_layer["objects"].ToString());
						foreach (dynamic _region in _objectsJson)
						{
							Rectangle _newRegion = new Rectangle(
								int.Parse(_region["x"].ToString()),
								int.Parse(_region["y"].ToString()),
								int.Parse(_region["width"].ToString()),
								int.Parse(_region["height"].ToString())
							);

							if (_region["type"].ToString().Contains("_start"))
							{
								_newMap.PlayerStartRegions.Add(_newRegion);
							}
							else if (_region["type"].ToString().Contains("control_point"))
							{
								_newMap.ControlPointRegions.Add(_newRegion);
							}
						}
					}
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
					if (_tileset["tileproperties"] != null)
					{
						foreach (dynamic _tile in (JObject)_tileset["tileproperties"])
						{
							foreach (dynamic _tileProperty in _tile.Value)
							{
								switch ((string)_tileProperty.Name)
								{
									case "tiletype":
										ChangeTileType(
											int.Parse(_tile.Key) + _newTileset.FirstID,            // Tile numbering starts at 0 here for reasons unknown, so we have to add the Id for the first tile
											_tileProperty.Value.ToString(),
											_newMap
										);
										break;

									default:
										break;
								}
							}
						}
					}

					_newMap.TileSetData.Add(_newTileset);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("A nondescript error occured while reading the map ¯\\_(ツ)_/¯\n" + ex.ToString());
			}

			return _newMap;
		}

		/// <summary>
		/// Verifies that a map object doesn't contain any errors.
		/// </summary>
		/// <param name="map">A map container object.</param>
		/// <returns>True or false, depending on the map's validity.</returns>
		public Boolean verifyMap(Map map)
		{
			// This mapreader can only read orthogonal maps
			if (map.MapOrientation != "orthogonal")
			{
				return false;
			}

			// The width&height of the map should be the same as the width&height of each of the layers
			foreach (MapTileLayer _layer in map.MapLayers)
			{
				if (_layer.LayerWidth != map.MapWidth || _layer.LayerHeight != map.MapHeight)
				{
					return false;
				}
			}

			// Map tiles should be square
			if (map.TileHeight != map.TileWidth)
			{
				return false;
			}

			// The width & height (in pixels) of the tiles should be the same
			foreach (MapTilesetData _tileset in map.TileSetData)
			{
				if (_tileset.TileHeight != map.TileHeight || _tileset.TileWidth != map.TileWidth)
				{
					return false;
				}
			}

			//TODO: The number of tiles in each layer should be equal to that layer's (width * height)
			foreach (MapTileLayer _layer in map.MapLayers)
			{
				if (_layer.Tiles.Count != (_layer.LayerWidth * _layer.LayerHeight))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Searches through a map's tiles to assign them a tiletype.
		/// </summary>
		/// <param name="tileNumberToChange">The tile numbers that will be replaced with the new type.</param>
		/// <param name="newTileType">A string representing the new tiletype.</param>
		/// <param name="map">The map object to replace tiles from.</param>
		/// <returns></returns>
		private int ChangeTileType(int tileNumberToChange, string newTileType, Map map)
		{
			int _tilesChanged = 0;

			foreach (MapTileLayer _layer in map.MapLayers)
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

	public class Rectangle
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;

		public Rectangle() { }

		public Rectangle(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
	}
}
