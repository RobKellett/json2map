using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class MapObjectLayer : MapLayer
	{
		List<MapObject> _objects;

		#region Properties
		public List<MapObject> Objects
		{
			get { if (_objects == null) { _objects = new List<MapObject>(); } return _objects; }
			set { _objects = value; }
		}
		#endregion

		#region Constructors
		public MapObjectLayer() { }

		public MapObjectLayer(int width, int height)
			: base(width, height)
		{
		}
		#endregion
	}
}
