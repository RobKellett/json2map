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
		const string referenceLevel01_filename = @"Level-Reference01_6-16.json";

		public string GetPath(string jsonFileName)
		{
			string path = Directory.GetFiles(
				Environment.CurrentDirectory, referenceLevel01_filename, SearchOption.AllDirectories
			).First();

			return path;
		}

		[TestMethod]
		// The system should ...
		public void ReturnMapObject()
		{
			// Get the json file
			string jsonFilePath = GetPath(referenceLevel01_filename);
			Assert.IsNotNull(jsonFilePath);

			// Initalize a new map
			Map _theMap = MapReader.ReadJson(File.ReadAllText(jsonFilePath));

			// Make sure the Map object is not null
			Assert.IsNotNull(_theMap);
		}

		[TestMethod]
		// The system should ...
		public void ReadMapData()
		{
			// Get the json file
			string jsonFilePath = GetPath(referenceLevel01_filename);
			Assert.IsNotNull(jsonFilePath);

			// Initalize a new map
			Map _theMap = MapReader.ReadJson(File.ReadAllText(jsonFilePath));

			Assert.IsNotNull(_theMap.MapHeight);
			Assert.IsNotNull(_theMap.MapWidth);
			Assert.IsNotNull(_theMap.MapOrientation);
		}

		[TestMethod]
		// The system should ...
		public void ReadMapLayers()
		{
			// Get the json file
			string jsonFilePath = GetPath(referenceLevel01_filename);
			Assert.IsNotNull(jsonFilePath);

			// Initalize a new map
			Map _theMap = MapReader.ReadJson(File.ReadAllText(jsonFilePath));

			Assert.IsNotNull(_theMap.MapLayers);
			Assert.IsTrue(_theMap.MapLayers.Count > 0);
		}

		[TestMethod]
		// The system should ...
		public void ReadMapTilesets()
		{
			// Get the json file
			string jsonFilePath = GetPath(referenceLevel01_filename);
			Assert.IsNotNull(jsonFilePath);

			// Initalize a new map
			Map _theMap = MapReader.ReadJson(File.ReadAllText(jsonFilePath));

			Assert.IsNotNull(_theMap.Tilesets);
			Assert.IsTrue(_theMap.Tilesets.Count > 0);
		}

		[TestMethod]
		// The system should ...
		public void ReadMapTilesetsTiles()
		{
			// Get the json file
			string jsonFilePath = GetPath(referenceLevel01_filename);
			Assert.IsNotNull(jsonFilePath);

			// Initalize a new map
			Map _theMap = MapReader.ReadJson(File.ReadAllText(jsonFilePath));

			Assert.IsNotNull(_theMap.Tilesets[0]);
			Assert.IsNotNull(_theMap.Tilesets[0].FirstID);
			Assert.IsNotNull(_theMap.Tilesets[1]);
			Assert.IsNotNull(_theMap.Tilesets[1].FirstID);
		}
	}
}
