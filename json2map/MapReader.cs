using System;
using Json2Map.MapObjects;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Json2Map
{
	public static class MapReader
	{
		/// <summary>
		/// Takes a string of JSON-formatted Tiled data and returns a POCO Map container object.
		/// </summary>
		/// <param name="jsonString">The JSON string.</param>
		/// <returns>A map container object.</returns>
		public static Map ReadJson(string jsonString)
		{
			Map _newMap = new Map();

			_newMap = JsonConvert.DeserializeObject<Map>(jsonString);

			return _newMap;
		}
	}
}
