using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Net;

using Newtonsoft.Json;

namespace Task4
{

	interface IUpdate_DL
	{
		void Update_Divers_Logbook(decimal newDive_Nr, string newDive_Location, decimal reached_Depth);
		void Insert_Divers_Logbook(decimal newDive_Nr);
	}

	interface IUpdate_DC
	{
		void Insert_Number_of_Dives(decimal newNumberOfDives);
	}

	public class Divers_Card : IUpdate_DC
	{
		/// <summary>
		/// public proerty
		/// Gets and Sets the Numer of Dives.
		/// </summary>
		public decimal NumberOfDives { get; set; }

		public Divers_Card(decimal newNumberOfDives)
		{
			Insert_Number_of_Dives(newNumberOfDives);
		}

		public void Insert_Number_of_Dives(decimal newNumberOfDives)
		{
			if (newNumberOfDives < 0) throw new ArgumentException("Number of Dives must be given and greater 0.", nameof(newNumberOfDives));
			NumberOfDives = newNumberOfDives;
		}
		public decimal Print_Number_of_Dives(decimal newNumberOfDives)
		{
			if (newNumberOfDives < 0) throw new ArgumentException("Number of Dives must be given and greater 0.", nameof(newNumberOfDives));
			return newNumberOfDives;
		}
	}


	public class Divers_Logbook : IUpdate_DL
	{

		/// <summary>
		/// private fields
		/// The m_location.
		/// The m_depth.
		/// </summary>
		private string m_location;
		private decimal m_depth;
		private decimal m_decimal;
		private string m_string;


		/// <summary>
		/// constructor, creates a new object, the Divers_Logbook.
		/// </summary>
		/// <param name="number"></param>
		public Divers_Logbook(decimal number, int action, decimal newDive_Nr, string newDive_Location, decimal newDepth)
		{
			///Console.WriteLine("Divers_Logbook called");
			if (number < 0) throw new ArgumentException("Dive Number must be given and greater 0.", nameof(number));

			/// <summary>
			///call Insert_Divers_Logbook() or Update_Divers_Logbook() depending on given action
			/// <summary>

			switch (action)
			{
				case 1:
					Console.WriteLine("switch: Insert_Divers_Logbook called");
					Insert_Divers_Logbook(number);
					break;
				case 2:
					Console.WriteLine("switch: Update_Divers_Logbook called");
					if (newDive_Nr <= 0)
					{
						newDive_Nr = number;
						string newDiveLocation = get_string("Please enter the location: ");
						newDepth = get_decimal("Please enter the Depth [in meters]: ");
						Update_Divers_Logbook(newDive_Nr, newDiveLocation, newDepth);
					}
					break;
				default:
					Console.WriteLine("Default case");
					break;
			}
		}


		/// <summary>
		/// public proerty
		/// Gets and Sets the Dive Number.
		/// </summary>
		public decimal Dive_Nr { get; set; }

		/// <summary>
		/// public proerty
		/// Gets and Sets the Location.
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// public proerty
		/// Gets and Sets the Depth of the Dive.
		/// </summary>
		public decimal Depth { get; set; }


		public decimal get_decimal(string text)
		{
			if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("get_decimal must be called with <string> as an argument!", nameof(text));
			Console.WriteLine("{0}", text);
			m_decimal = Convert.ToInt32(Console.ReadLine());
			return m_decimal;
		}

		public string get_string(string text)
		{
			if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("get_string must be called with <string> as an argument!", nameof(text));
			Console.WriteLine("{0}", text);
			m_string = Console.ReadLine();
			return m_string;
		}

		/// <summary>
		/// public method
		/// Inserts one record in the Divers Logbook.
		/// </summary>
		/// <param name="newDive_Nr"></param>
		public void Insert_Divers_Logbook(decimal newDive_Nr)
		{
			bool repeat = true;

			if (newDive_Nr < 0) throw new ArgumentException("Dive Number must be given and greater 0.", nameof(newDive_Nr));

			/// Console.WriteLine("Insert_Divers_Logbook called");
			Console.Out.NewLine = "\t";
			Console.WriteLine("Please enter the location: \t");
			m_location = Console.ReadLine();
			Console.Out.NewLine = "\r\n";

			while (repeat)
			{
				Console.Out.NewLine = "\t";
				Console.WriteLine("Please enter the Depth [in meters]: ");
				string input = Console.ReadLine();
				Console.Out.NewLine = "\r\n";

				/// <summary>
				/// Handle ToInt32 Execptions - FormatException or OverflowException.
				/// nessesary to be save getting an regular value, an int
				/// <summary>
				try
				{
					m_depth = Convert.ToInt32(input);
				}
				catch (FormatException)
				{
					Console.WriteLine("Input string is not a sequence of digits.");
				}
				catch (OverflowException)
				{
					Console.WriteLine("The number cannot fit in an Int32.");
				}
				if (m_depth == 0)
				{
					repeat = true;
				}
				else
				{
					repeat = false;
				}
			}

			///Dive_Nr = newDive_Nr;
			///Location = m_location;
			///Depth = m_depth;
		}

		/// <summary>
		/// public method
		/// Updates the Divers Logbook.
		/// </summary>
		/// <param name="newDive_Nr">Nr could not be empty.</param>
		/// <param name="newDive_Location">Location could not be empty.</param>
		/// <param name="reached_Depth">Depth must be greater than 0.</param>
		public void Update_Divers_Logbook(decimal newDive_Nr, string newDive_Location, decimal reached_Depth)
		{
			if (newDive_Nr < 0) throw new ArgumentException("Dive Number must be given and greater 0.", nameof(newDive_Nr));
			if (string.IsNullOrWhiteSpace(newDive_Location)) throw new ArgumentException("Dive Location must not be empty.", nameof(newDive_Location));
			if (reached_Depth < 0) throw new ArgumentException("Depth must be given and greater 0.", nameof(reached_Depth));
			Dive_Nr = newDive_Nr;
			Location = newDive_Location;
			Depth = reached_Depth;
			Console.WriteLine("Update_Divers_Logbook called");
		}


		/// <summary>
		/// Divers logbook. Trying Serialisation
		/// </summary>


		/// Divers_Logbook sdivers_logbook = new Divers_Logbook(1, 1, 2, "Dummy", 23);
		///Divers_Logbook sdivers_logbook = new Divers_Logbook()
		///{
		///	Dive_Nr = 1,
		///	Location = "Fidschii",
		///	Depth = 25
		///};

		///string json = JsonConvert.SerializeObject(sdivers_logbook);
		///Console.Writeline(json);
		///Console.WriteLine(JsonConvert.SerializeObject(sdivers_logbook));
		/// END ##################



	/// <summary>
	/// Main Function
	/// </summary>
	static void Main()
		{
			Console.WriteLine("My first C# Program - OOM Task2");

			/// <summary>
			/// Inserts for example 3 Records into the Divers_Logbook
			/// <summary>
			Console.WriteLine("Inserting now 3 records into Divers Logbook");
			var Divers_Logbook = new[]
			{
				new Divers_Logbook(1,1,2,"Dummy",23),
				new Divers_Logbook(2,1,2,"Dummy",23),
				new Divers_Logbook(3,1,2,"Dummy",23),
			};


			/// <summary>
			/// Print each Record of the Divers_Logbook
			/// <summary>
			Console.WriteLine("\n\nListing all records of Divers Logbook");
			foreach (var b in Divers_Logbook)
			{
				Console.WriteLine("{0} {1} {2}", b.Dive_Nr, b.Location, b.Depth);
			}
			Console.WriteLine("-------------------------------------------");


			/// <summary>
			/// get the number of records in Divers_Logbook
			/// </summary>
			int dlb_count = 0;
			foreach (var b in Divers_Logbook)
			{
				dlb_count += 1;
			}
			Console.WriteLine("number of records in the logbook: {0}\n\n", dlb_count);

			Divers_Card dc = new Divers_Card(dlb_count);
			Console.WriteLine("number of Dives on Divers Card: {0}\n\n", dc.Print_Number_of_Dives(dc.NumberOfDives));

			/// <summary>
			/// Update for example the Location of the "last minus 1 Record" in the Divers_Logbook
			/// <summary>
			Console.WriteLine("Updating one record in Divers Logbook");
			foreach (var c in Divers_Logbook)
			{
				if (c.Dive_Nr == dlb_count - 1)
				{
					c.Update_Divers_Logbook(c.Dive_Nr, "Island_Update", c.Depth + 10);
				}
			}


			/// <summary>
			/// Print again each Record of the Divers_Logbook
			/// <summary>
			Console.WriteLine("\n\nListing all records of Divers Logbook");
			foreach (var d in Divers_Logbook)
			{
				Console.WriteLine("{0} {1} {2}", d.Dive_Nr, d.Location, d.Depth);
			}
			Console.WriteLine("-------------------------------------------");



		}

	}
}

