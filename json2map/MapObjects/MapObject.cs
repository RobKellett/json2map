using Newtonsoft.Json;

namespace Json2Map.MapObjects
{
	public class MapObject
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "x")]
		public int X { get; set; }

		[JsonProperty(PropertyName = "y")]
		public int Y { get; set; }

		[JsonProperty(PropertyName = "width")]
		public int Width { get; set; }

		[JsonProperty(PropertyName = "height")]
		public int Height { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "rotation")]
		public float Rotation { get; set; }

		[JsonProperty(PropertyName = "visible")]
		public bool Visible { get; set; }
	}
}
