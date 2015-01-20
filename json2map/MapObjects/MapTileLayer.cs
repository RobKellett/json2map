using System.Collections.Generic;

namespace Json2Map.Maps.MapObjects
{
	class MapTileLayer : MapLayer
	{
		List<MapTile> _tiles;

		#region Properties
		public List<MapTile> Tiles
		{
			get { if (_tiles == null) { _tiles = new List<MapTile>(); } return _tiles; }
			set { _tiles = value; }
		}
		#endregion

		#region Constructors
		public MapTileLayer() { }

		public MapTileLayer(int width, int height)
			: base(width, height)
		{
		}
		#endregion
	}
}
