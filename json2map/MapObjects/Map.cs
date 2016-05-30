using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	enum MapOrientation
	{
		Unspecified,
		Isometric,
		Orthogonal
	}

	public class Map
	{
		private int mapWidth;
		public int MapWidth {
			get;
			set;
		}

		private int mapHeight;
		public int MapHeight
		{
			get;
			set;
		}

		private int tileWidth;
		public int TileWidth
		{
			get;
			set;
		}

		private int tileHeight;
		public int TileHeight
		{
			get;
			set;
		}

		private string _mapOrientation;
		public string MapOrientation
		{
			get {
				return _mapOrientation;
			}
			set
			{
				if (value == "orthogonal" || value == "isometric")
					_mapOrientation = value;
				else
					_mapOrientation = "INVALID";
			}
		}

		private List<MapLayer> _mapTileLayers;
		public List<MapLayer> MapLayers
		{
			get { if (_mapTileLayers == null) { _mapTileLayers = new List<MapLayer>(); } return _mapTileLayers; }
			set { _mapTileLayers = value; }
		}

		private List<MapTilesetData> _tileSetData;
		public List<MapTilesetData> TileSetData
		{
			get { if (_tileSetData == null) { _tileSetData = new List<MapTilesetData>(); } return _tileSetData; }
			set { _tileSetData = value; }
		}

		private List<Rectangle> _playerStartRegions;
		public List<Rectangle> PlayerStartRegions
		{
			get { if (_playerStartRegions == null) { _playerStartRegions = new List<Rectangle>(); } return _playerStartRegions; }
		}

		private List<Rectangle> _controlPointRegions;
		public List<Rectangle> ControlPointRegions
		{
			get { if (_controlPointRegions == null) { _controlPointRegions = new List<Rectangle>(); } return _controlPointRegions; }
		}

		private MapLayer _objectLayer;
		public MapLayer ObjectLayer { get; set; }


		public Map() { }

		public Map(int width, int height)
		{
			mapWidth = width;
			mapHeight = height;
		}
	}
}
