using System.Collections.Generic;

namespace json2map.MapObjects
{
	class MapLayer
	{
		private int _layerWidth;
		private int _layerHeight;

		private string _layerName;

		private float _layerDepth;
		
		List<MapTile> _tiles;

		#region Properties
		public int LayerWidth
		{
			get { return _layerWidth; }
			set { _layerWidth = value; }
		}
		public int LayerHeight
		{
			get { return _layerHeight; }
			set { _layerHeight = value; }
		}

		public string LayerName
		{
			get { return _layerName; }
			set { _layerName = value; }
		}

		public float LayerDepth
		{
			get { return _layerDepth; }
			set { _layerDepth = value; }
		}

		public List<MapTile> Tiles
		{
			get { if (_tiles == null) { _tiles = new List<MapTile>(); } return _tiles; }
			set { _tiles = value; }
		}
		#endregion

		#region Constructors
		public MapLayer() { }

		public MapLayer(int width, int height)
		{
			_layerWidth = width;
			_layerHeight = height;
		}
		#endregion
	}
}
