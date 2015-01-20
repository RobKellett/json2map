namespace Json2Map.Maps.MapObjects
{
	enum MapTileType
	{
		Empty,
		Solid,
		Door
	}

	class MapTile
	{
		private MapTileType _mapTileType;

		private int _tileNumber;

		#region Properties
		public MapTileType TileType
		{
			get { return _mapTileType; }
			set { _mapTileType = value; }
		}

		public int TileNumber
		{
			get { return _tileNumber; }
			set { _tileNumber = value; }
		}
		#endregion

		#region Constructors
		public MapTile()
		{
			_mapTileType = MapTileType.Empty;
		}

		public MapTile(int tileNumber)
		{
			_tileNumber = tileNumber;
		}
		#endregion
	}
}
