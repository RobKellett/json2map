using Newtonsoft.Json;
using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class MapLayer
	{
		[JsonProperty(PropertyName = "width")]
		public int Width { get; set; }

		[JsonProperty(PropertyName = "height")]
		public int Height { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "visible")]
		public bool Visible { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		//TODO: Opacity
		//TODO: X
		//TODO: Y

		[JsonProperty(PropertyName = "data")]
		public List<int> Tiles { get; set; }

		[JsonProperty(PropertyName = "objects")]
		public List<MapObject> Objects { get; set; }


		public MapLayer(int width, int height)
		{
			Tiles = new List<int>();
			Objects = new List<MapObject>();
		}
	}
}
