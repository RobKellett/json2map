using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Json2Map.Utilities
{
	class MapTilesetTileConverter : JsonConverter
	{
		protected MapTilesetTileConverter Create(Type objectType, JObject jObject)
		{
			//if (jObject["name"] != null)
			//{
			//	if (jObject["name"].ToString() == "position")
			//	{
			//		return new Position();
			//	}
			//	else if (jObject["name"].ToString() == "health")
			//	{
			//		return new Health();
			//	}
			//}

			//return new Component();

			return new MapTilesetTileConverter();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			JObject jObject = JObject.Load(reader);

			// Create target object based on JObject
			MapTilesetTileConverter target = Create(objectType, jObject);

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();

			//if (value is Position)
			//{
			//	Position position = (Position)value;
			//	writer.WriteStartObject();
			//	writer.WritePropertyName("name");
			//	writer.WriteValue(position.Name);
			//	writer.WritePropertyName("x");
			//	writer.WriteValue(position.x);
			//	writer.WritePropertyName("y");
			//	writer.WriteValue(position.y);
			//	writer.WriteEndObject();
			//}
			//else if (value is Health)
			//{
			//	Health health = (Health)value;
			//	writer.WriteStartObject();
			//	writer.WritePropertyName("name");
			//	writer.WriteValue(health.Name);
			//	writer.WritePropertyName("HP");
			//	writer.WriteValue(health.HP);
			//	writer.WriteEndObject();
			//}
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(MapTilesetTileConverter).IsAssignableFrom(objectType);
		}
	}
}
