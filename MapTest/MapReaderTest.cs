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
		const string invalidLevel01_filename = @"invalidlevel01.json";

		[TestMethod]
		// The system should ...
		public void ParseMaps()
		{
			// Get the json file
			string _path = Directory.GetFiles(
				Environment.CurrentDirectory, validLevel01_filename, SearchOption.AllDirectories
			).First();
			Assert.IsNotNull(_path);

			// Initalize a new map
			MapReader _mapReader = new MapReader(new MapConfig { MapLayers_Min = 0.0f, MapLayers_Max = 1.0f });
			Map _theMap = _mapReader.ReadJson(File.ReadAllText(_path));

			// Make sure the Map object is not null
			Assert.IsNotNull(_theMap);
		}

		[TestMethod]
		// The system should ...
		public void VerifyValidMaps()
		{
			MapReader _mapReader = new MapReader(new MapConfig { MapLayers_Min = 0.0f, MapLayers_Max = 1.0f });

			// Get the json file (for the valid map)
			string _path_valid = Directory.GetFiles(
				Environment.CurrentDirectory, validLevel01_filename, SearchOption.AllDirectories
			).First();
			Assert.IsNotNull(_path_valid);

			// Initalize a new map (for the valid map)
			Map _theValidMap = _mapReader.ReadJson(File.ReadAllText(_path_valid));

			// Verify that the map is valid (for the valid map)
			Assert.IsTrue(
				_mapReader.verifyMap(_theValidMap)
			);
		}

		[TestMethod]
		// The system should ...
		public void RecognizeInvalidMaps()
		{
			MapReader _mapReader = new MapReader(new MapConfig { MapLayers_Min = 0.0f, MapLayers_Max = 1.0f });

			// Get the json file (for the invalid map)
			string _path_invalid = Directory.GetFiles(
				Environment.CurrentDirectory, invalidLevel01_filename, SearchOption.AllDirectories
			).First();
			Assert.IsNotNull(_path_invalid);

			// Initalize a new map (for the invalid map)
			Map _theInvalidMap = _mapReader.ReadJson(File.ReadAllText(_path_invalid));

			// Verify that the map is invalid (for the invalid map)
			Assert.IsFalse(
				_mapReader.verifyMap(_theInvalidMap)
			);
		}
	}
}
