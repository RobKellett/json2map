namespace Json2Map.MapObjects
{
	public class MapTile
	{
		private MapTileType _mapTileType;
		public MapTileType TileType
		{
			get { return _mapTileType; }
			set { _mapTileType = value; }
		}

		private int _tileNumber;
		public int TileNumber
		{
			get { return _tileNumber; }
			set { _tileNumber = value; }
		}


		public MapTile()
		{
			_mapTileType = MapTileType.Empty;
		}

		public MapTile(int tileNumber)
		{
			_tileNumber = tileNumber;
		}
	}
}
