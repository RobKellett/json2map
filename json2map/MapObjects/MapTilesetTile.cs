using Newtonsoft.Json;
using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class MapTilesetTile
	{
		[JsonProperty(PropertyName = "objectGroup")]
		public MapTilesetTileObjectGroup ObjectGroup{ get; set; }

		[JsonProperty(PropertyName = "terrain")]
		public List<int> Terrain { get; set; }


		public MapTilesetTile()
		{
			Terrain = new List<int>();
		}
	}

	public class MapTilesetTileObjectGroup
	{
		[JsonProperty(PropertyName = "height")]
		public int Height{ get; set; }

		[JsonProperty(PropertyName = "width")]
		public int Width { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "visible")]
		public bool Visible { get; set; }

		[JsonProperty(PropertyName = "x")]
		public int X { get; set; }

		[JsonProperty(PropertyName = "y")]
		public int Y { get; set; }

		[JsonProperty(PropertyName = "objects")]
		public List<MapTilesetTileObject> Objects { get; set; }

		//TODO: Opacity, DrawOrder


		public MapTilesetTileObjectGroup()
		{
			Objects = new List<MapTilesetTileObject>();
		}
	}

	public class MapTilesetTileObject
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "height")]
		public int Height { get; set; }

		[JsonProperty(PropertyName = "width")]
		public int Width { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "visible")]
		public bool Visible { get; set; }

		[JsonProperty(PropertyName = "x")]
		public int X { get; set; }

		[JsonProperty(PropertyName = "y")]
		public int Y { get; set; }

		[JsonProperty(PropertyName = "polygon")]
		public List<PolygonPoint> Polygon { get; set; }

		//TODO: Opacity, DrawOrder


		public MapTilesetTileObject()
		{
			Polygon = new List<PolygonPoint>();
		}
	}

	public class PolygonPoint
	{
		[JsonProperty(PropertyName = "x")]
		public int X { get; set; }

		[JsonProperty(PropertyName = "y")]
		public int Y { get; set; }
	}
}
