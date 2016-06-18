using Json2Map.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Json2Map.MapObjects
{
	public class MapTilesetData
	{
		[JsonProperty(PropertyName = "firstgid")]
		public int FirstID { get; set; }
		
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "image")]
		public string TilesetPath { get; set; }

		[JsonProperty(PropertyName = "imagewidth")]
		public int TilesetWidth { get; set; }

		[JsonProperty(PropertyName = "imageheight")]
		public int TilesetHeight { get; set; }

		[JsonProperty(PropertyName = "tilewidth")]
		public int TileWidth { get; set; }

		[JsonProperty(PropertyName = "tileheight")]
		public int TileHeight { get; set; }

		[JsonProperty(PropertyName = "tilecount")]
		public int TileCount{ get; set; }

		[JsonProperty(PropertyName = "columns")]
		public int Columns { get; set; }

		[JsonProperty(PropertyName = "tiles"), JsonConverter(typeof(MapTilesetTileConverter))]
		public Dictionary<int, MapTilesetTile> Tiles { get; set; }

		//TODO: Margin, Spacing, Terrains

		public MapTilesetData()
		{
			Tiles = new Dictionary<int, MapTilesetTile>();
		}
	}
}
