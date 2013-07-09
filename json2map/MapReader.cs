using System;
using System.Collections.Generic;
using System.Linq;
using json2map.Level;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace json2map
{
	static class MapReader
	{
		public static Map readJson(string jsonString)
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

				// Width and height of the map (tiles)
				_newMap.MapWidth = int.Parse(_mapJson["width"].ToString());
				_newMap.MapHeight = int.Parse(_mapJson["height"].ToString());

				// Width and height of each tile (pixels)
				_newMap.TileWidth = int.Parse(_mapJson["tilewidth"].ToString());
				_newMap.TileHeight = int.Parse(_mapJson["tileheight"].ToString());

				// Parse misc. map info
				_newMap.MapOrientation = _mapJson["orientation"].ToString();

				// Parse the map's tileset data
				JArray _tilesetsJson = JArray.Parse(_mapJson["tilesets"].ToString());
				foreach (dynamic _tileset in _tilesetsJson)
				{
					TilesetData _newTileset = new TilesetData();

					// Numeric ID of first tile in this tileset
					_newTileset.FirstID = int.Parse(_tileset["firstgid"].ToString());

					// Tileset name and path
					_newTileset.TilesetName = _tileset["name"].ToString();
					_newTileset.TilesetPath = _tileset["image"].ToString();

					// Tileset width and height (full)
					_newTileset.TilesetWidth = int.Parse(_tileset["imagewidth"].ToString());
					_newTileset.TilesetHeight = int.Parse(_tileset["imageheight"].ToString());

					// Width and height of each tile
					_newTileset.TileWidth = int.Parse(_tileset["tilewidth"].ToString());
					_newTileset.TileHeight = int.Parse(_tileset["tileheight"].ToString());

					_newMap.TileSetData.Add(_newTileset);
				}

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
						List<string> _tiles = new List<string>(_layer["data"].ToString().Substring(1, _layer["data"].ToString().Length - 2).Split(','));
						foreach (dynamic _tile in _tiles)
						{
							MapTile _newTile = new MapTile(int.Parse(_tile));
							_newLayer.Tiles.Add(_newTile);
						}
					}

					_newLayer.LayerName = _layer.name.ToString();
					_newMap.MapLayers.Add(_newLayer);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("An error occured while reading the map:\n" + ex.ToString());
			}

			return _newMap;
		}

		public static Boolean verifyMap(Map map)
		{
			// The map should have orientation = "orthoganal"
			if (map.MapOrientation != "orthogonal")
			{
				return false;
			}

			// The width&height of the map should be the same as the width&height of each of the layers
			foreach (MapLayer _layer in map.MapLayers)
			{
				if (_layer.LayerWidth != map.MapWidth || _layer.LayerHeight != map.MapHeight)
				{
					//Console.WriteLine("Error in map layer '" + _layer.LayerName + "'!");
					return false;
				}
			}

			// The width&height of the tiles should be the same
			// The number of tiles in each layer should be equal to that layer's (width * height)


			return true;
		}
	}
}
