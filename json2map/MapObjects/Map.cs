using Newtonsoft.Json;
using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class Map
	{
		[JsonProperty(PropertyName = "width")]
		public int MapWidth { get; set; }

		[JsonProperty(PropertyName = "height")]
		public int MapHeight { get; set; }

		[JsonProperty(PropertyName = "tilewidth")]
		public int TileWidth { get; set; }

		[JsonProperty(PropertyName = "tileheight")]
		public int TileHeight { get; set; }

		[JsonProperty(PropertyName = "orientation")]
		public string MapOrientation { get; set; }
		
		[JsonProperty(PropertyName = "layers")]
		public List<MapLayer> MapLayers { get; set; }

		[JsonProperty(PropertyName = "tilesets")]
		public List<MapTilesetData> Tilesets { get; set; }


		public Map()
		{
			MapLayers = new List<MapLayer>();
			Tilesets = new List<MapTilesetData>();
		}
	}
}
