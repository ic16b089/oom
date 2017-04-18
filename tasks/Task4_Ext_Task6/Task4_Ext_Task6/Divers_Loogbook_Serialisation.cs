using System;
using System.IO;
using Newtonsoft.Json;


namespace Task4_Ext_Task6
{
	public class Divers_Loogbook_Serialisation
	{
		public static void Run(IUtilities_DL[] items)
		{
			var my_divers_logbook = items[0];


			// Serialize the divers logbook to a JSON string
			var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
			Console.WriteLine(JsonConvert.SerializeObject(items, settings));


			// Store json string to file "divers_logbook.json" on your Desktop 
			var text = JsonConvert.SerializeObject(items, settings);
			var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var filename = Path.Combine(desktop, "divers_logbook.json");
			File.WriteAllText(filename, text);


			// Deserialize
			// Read from file "divers_logbook.json" and print the content of deserialized items of Divers Logbook 
			Console.WriteLine("\n\n Deserialise and Read from File <{0}>\n\n", filename);
			var textFromFile = File.ReadAllText(filename);
			Console.WriteLine(textFromFile);

		}

	}
}
