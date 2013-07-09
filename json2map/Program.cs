using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace json2map
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				// Open a JSON map to read
				string json = File.ReadAllText(fileDialog.FileName);

				// Parse the JSON into a new Map object
				Level.Map newMap = MapReader.readJson(json);

				// Verify the map
				if (!MapReader.verifyMap(newMap))
				{
					Console.WriteLine(Environment.NewLine + "This map has been deemed unsuitable for human consumption and must be destroyed.");
				}
				else
				{
					Console.WriteLine(Environment.NewLine + "Yep, it's a map, alright.");
				}

				Console.ReadKey();
			}
		}
	}
}
