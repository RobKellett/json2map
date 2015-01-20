using System.Collections.Generic;

namespace Json2Map.Maps.MapObjects
{
	enum MapOrientation
	{
		Unspecified,
		Isometric,
		Orthogonal
	}

	class Map
	{
		private int mapWidth;
		private int mapHeight;

		private int tileWidth;
		private int tileHeight;

		private string _mapOrientation;

		private List<MapTileLayer> _mapTileLayers;

		private List<MapTilesetData> _tileSetData;

		private List<Rectangle> _playerStartRegions;
		private List<Rectangle> _controlPointRegions;

		private MapLayer _objectLayer;

		#region Properties
		public int MapWidth
		{
			get { return mapWidth; }
			set { mapWidth = value; }
		}
		public int MapHeight
		{
			get { return mapHeight; }
			set { mapHeight = value; }
		}

		public int TileWidth
		{
			get { return tileWidth; }
			set { tileWidth = value; }
		}
		public int TileHeight
		{
			get { return tileHeight; }
			set { tileHeight = value; }
		}

		public string MapOrientation
		{
			get { return _mapOrientation; }
			set
			{
				if (value == "orthogonal" || value == "isometric")
					_mapOrientation = value;
				else
					_mapOrientation = "INVALID";
			}
		}

		public List<MapTileLayer> MapLayers
		{
			get { if (_mapTileLayers == null) { _mapTileLayers = new List<MapTileLayer>(); } return _mapTileLayers; }
			set { _mapTileLayers = value; }
		}

		public List<MapTilesetData> TileSetData
		{
			get { if (_tileSetData == null) { _tileSetData = new List<MapTilesetData>(); } return _tileSetData; }
			set { _tileSetData = value; }
		}

		public List<Rectangle> PlayerStartRegions
		{
			get { if (_playerStartRegions == null) { _playerStartRegions = new List<Rectangle>(); } return _playerStartRegions; }
		}

		public List<Rectangle> ControlPointRegions
		{
			get { if (_controlPointRegions == null) { _controlPointRegions = new List<Rectangle>(); } return _controlPointRegions; }
		}

		public MapLayer ObjectLayer
		{
			get { return _objectLayer; }
			set { _objectLayer = value; }
		}
		#endregion

		#region Constructors
		public Map() { }

		public Map(int width, int height)
		{
			mapWidth = width;
			mapHeight = height;
		}
		#endregion

		public int[,] GetMapPassability()
		{
			int[,] _passability = new int[mapHeight, mapWidth];

			for (int _countX = 0; _countX < mapWidth; _countX++)
			{
				for (int _countY = 0; _countY < mapHeight; _countY++)
				{
					// Assume terrain is passable until proven otherwise
					//TODO: Good idea?
					_passability[_countY, _countX] = 0;
					foreach (MapTileLayer _layer in _mapTileLayers)
					{
						if (_layer.Tiles[(_countY * mapHeight) + _countX].TileType > MapTileType.Empty)
						{
							_passability[_countY, _countX] = 1;
						}
					}
				}
			}

			return _passability;
		}
	}
}
