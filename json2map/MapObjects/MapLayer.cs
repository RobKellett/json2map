namespace Json2Map.Maps.MapObjects
{
	class MapLayer
	{
		private int _layerWidth;
		private int _layerHeight;

		private string _layerName;

		private float _layerDepth;

		private bool _layerVisibility;

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

		public bool LayerVisibility
		{
			get { return _layerVisibility; }
			set { _layerVisibility = value; }
		}
		#endregion

		#region Constructors
		public MapLayer() { }

		public MapLayer(int width, int height)
		{
			_layerWidth = width;
			_layerHeight = height;

			_layerVisibility = false;
		}
		#endregion
	}
}
