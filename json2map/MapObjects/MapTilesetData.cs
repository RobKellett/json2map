namespace TinyDungeon.Utils.Maps.MapObjects
{
	class MapTilesetData
	{
		private int _firstID;

		private string _tilesetName;
		private string _tilesetPath;

		private int _tilesetWidth;
		private int _tilesetHeight;

		private int _tileWidth;
		private int _tileHeight;

		//private int _spacing;
		//private int _margrin;

		#region Properties
		public int FirstID{
			get { return _firstID; }
			set { _firstID = value; }
		}

		public string TilesetName
		{
			get { return _tilesetName; }
			set { _tilesetName = value; }
		}
		public string TilesetPath
		{
			get { return _tilesetPath; }
			set { _tilesetPath = value; }
		}

		public int TilesetWidth
		{
			get { return _tilesetWidth; }
			set { _tilesetWidth = value; }
		}
		public int TilesetHeight
		{
			get { return _tilesetHeight; }
			set { _tilesetHeight = value; }
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
		#endregion

		#region Constructors
		public MapTilesetData() { }
		#endregion
	}
}
