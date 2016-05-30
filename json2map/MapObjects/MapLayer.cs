using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class MapLayer
	{
		private int _layerWidth;
		public int LayerWidth
		{
			get { return _layerWidth; }
			set { _layerWidth = value; }
		}

		private int _layerHeight;
		public int LayerHeight
		{
			get { return _layerHeight; }
			set { _layerHeight = value; }
		}

		private string _layerName;
		public string LayerName
		{
			get { return _layerName; }
			set { _layerName = value; }
		}

		private float _layerDepth;
		public float LayerDepth
		{
			get { return _layerDepth; }
			set { _layerDepth = value; }
		}

		private bool _layerVisibility;
		public bool LayerVisibility
		{
			get { return _layerVisibility; }
			set { _layerVisibility = value; }
		}

		private List<MapObject> _objects;
		public List<MapObject> Objects
		{
			get { if (_objects == null) { _objects = new List<MapObject>(); } return _objects; }
			set { _objects = value; }
		}

		List<MapTile> _tiles;
		public List<MapTile> Tiles
		{
			get { if (_tiles == null) { _tiles = new List<MapTile>(); } return _tiles; }
			set { _tiles = value; }
		}
		

		public MapLayer() { }

		public MapLayer(int width, int height)
		{
			_layerWidth = width;
			_layerHeight = height;

			_layerVisibility = false;
		}
	}
}
