namespace Json2Map.MapObjects
{
	public class MapTilesetData
	{
		private int _firstId;
		public int FirstID
		{
			get { return _firstId; }
			set { _firstId = value; }
		}

		private string _tilesetName;
		public string TilesetName
		{
			get { return _tilesetName; }
			set { _tilesetName = value; }
		}

		private string _tilesetPath;
		public string TilesetPath
		{
			get { return _tilesetPath; }
			set { _tilesetPath = value; }
		}

		private int _tilesetWidth;
		public int TilesetWidth
		{
			get { return _tilesetWidth; }
			set { _tilesetWidth = value; }
		}

		private int _tilesetHeight;
		public int TilesetHeight
		{
			get { return _tilesetHeight; }
			set { _tilesetHeight = value; }
		}

		private int _tileWidth;
		public int TileWidth
		{
			get { return _tileWidth; }
			set { _tileWidth = value; }
		}

		private int _tileHeight;
		public int TileHeight
		{
			get { return _tileHeight; }
			set { _tileHeight = value; }
		}


		public MapTilesetData() { }
	}
}
