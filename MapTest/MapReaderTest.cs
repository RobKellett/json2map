using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Json2Map;
using Json2Map.MapObjects;

namespace MapTest
{
	[TestClass]
	public class MapReaderTest
	{
		const string validLevel01_filename = @"validlevel01.json";
		//const string invalidLevel01_filename = @"invalidlevel01.json";

		[TestMethod]
		// The system should ...
		public void ParseMaps()
		{
			// Get the json file
			string path = Directory.GetFiles(
				Environment.CurrentDirectory, validLevel01_filename, SearchOption.AllDirectories
			).First();
			Assert.IsNotNull(path);

			// Initalize a new map
			MapReader mapReader = new MapReader(new MapConfig { MapLayers_Min = 0.0f, MapLayers_Max = 1.0f });
			Map theMap = mapReader.ReadJson(path);

			// Make sure the Map object is not null
			Assert.IsNotNull(theMap);
		}

		[TestMethod]
		// The system should ...
		public void VerifyMaps()
		{
			// Get the json file
			string path = Directory.GetFiles(
				Environment.CurrentDirectory, validLevel01_filename, SearchOption.AllDirectories
			).First();
			Assert.IsNotNull(path);

			// Initalize a new map
			MapReader mapReader = new MapReader(new MapConfig { MapLayers_Min = 0.0f, MapLayers_Max = 1.0f });
			Map theMap = mapReader.ReadJson(path);

			// Verify that the map is valid
			Assert.IsTrue(
				mapReader.verifyMap(theMap)
			);
		}
	}
}
