using System.Collections.Generic;

namespace json2map.Level
{
	enum MapOrientation
	{
		Unspecified,
		Isometric,
		Orthogonal
	}

	class Map
	{
		private int _mapWidth;
		private int _mapHeight;

		private int _tileWidth;
		private int _tileHeight;

		private string _mapOrientation;

		private List<MapLayer> _mapLayers;

		private List<TilesetData> _tileSetData;

		#region Properties
		public int MapWidth
		{
			get { return _mapWidth; }
			set { _mapWidth = value; }
		}
		public int MapHeight
		{
			get { return _mapHeight; }
			set { _mapHeight = value; }
		}

		public int TileWidth
		{
			get { return _tileWidth; }
			set { _tileWidth = value; }
		}
		public int TileHeight
		{
			get { return _tileHeight; }
			set { _tileHeight = value; }
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

		public List<MapLayer> MapLayers
		{
			get { if (_mapLayers == null) { _mapLayers = new List<MapLayer>(); } return _mapLayers; }
			set { _mapLayers = value; }
		}

		public List<TilesetData> TileSetData
		{
			get { if (_tileSetData == null) { _tileSetData = new List<TilesetData>(); } return _tileSetData; }
			set { _tileSetData = value; }
		}
		#endregion

		#region Constructors
		public Map() { }

		public Map(int width, int height)
		{
			_mapWidth = width;
			_mapHeight = height;
		}
		#endregion
	}
}
