using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task2
{
	public class Divers_Logbook
	{

		///private string m_location;
		///private decimal m_depth;

		/// <summary>
		/// constructor, creates a new object, the Divers_Logbook.
		/// </summary>
		/// <param name="number"></param>
		/// <param name="location"></param>
		/// <param name="depth"></param>
		public Divers_Logbook(decimal number, string location, decimal depth)
		{
			if (string.IsNullOrWhiteSpace(location)) throw new ArgumentException("Location must be given.", nameof(location));
			if (depth < 0) throw new ArgumentException("Depth must be given and greater 0.", nameof(depth));

			Console.WriteLine("Divers_Logbook called");
			Insert_Divers_Logbook(number, location, depth);
		}

		/// <summary>
		/// Gets and Sets the Dive Number.
		/// </summary>
		public decimal Dive_Nr { get; set; }

		/// <summary>
		/// Gets and Sets the Location.
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Gets and Sets the Depth of the Dive.
		/// </summary>
		public decimal Depth { get; set; }

		/// <summary>
		/// Inserts in the Divers Logbook.
		/// </summary>
		/// <param name="newNumber">Number could not be empty.</param>
		/// <param name="newDive_Location">Location could not be empty.</param>
		/// <param name="reached_Depth">Depth must be greater than 0.</param>
		public void Insert_Divers_Logbook(decimal newNumber, string newDive_Location, decimal reached_Depth)
		{
			Dive_Nr = newNumber;
			Location = newDive_Location;
			Depth = reached_Depth;
			Console.WriteLine("Insert_Divers_Logbook called");
		}


		/// <summary>
		/// Updates the Divers Logbook.
		/// </summary>
		/// <param name="newDive_Location">Location could not be empty.</param>
		/// <param name="reached_Depth">Depth must be greater than 0.</param>
		public void Update_Divers_Logbook(decimal newNumber, string newDive_Location, decimal reached_Depth)
		{
			///if (reached_Depth < 0) throw new ArgumentException("Depth must be given and greater 0.", nameof(reached_Depth));
			Dive_Nr = newNumber;
			Location = newDive_Location;
			Depth = reached_Depth;
			Console.WriteLine("Update_Divers_Logbook called");
		}







		/// <summary>
		/// Main Function
		/// </summary>
		static void Main()
		{
			Console.WriteLine("My first C# Program - OOM Task2");

			/// Insert Records into the Divers_Logbook
			var Divers_Logbook = new [] 
			{ 
				new Divers_Logbook(1, "Hawaii", 40),
				new Divers_Logbook(2, "Bahamas", 25),               
				new Divers_Logbook(3, "Kosamui", 30),
				new Divers_Logbook(4, "Island", 45),
				new Divers_Logbook(5, "Great Barrier Reef", 23),
			};


			/// Print each Record of the Divers_Logbook
			foreach (var b in Divers_Logbook)
			{
				Console.WriteLine("{0} {1} {2}", b.Dive_Nr, b.Location, b.Depth);
			}
			Console.WriteLine("-------------------------------------------");


			/// Update one Record in the Divers_Logbook
			foreach (var c in Divers_Logbook)
			{
				if (c.Dive_Nr == 4) 
				{
					c.Update_Divers_Logbook(c.Dive_Nr,"Island_Update", c.Depth);
				}
			}

			/// Print each Record of the Divers_Logbook
			foreach (var d in Divers_Logbook)
			{
				Console.WriteLine("{0} {1} {2}", d.Dive_Nr, d.Location, d.Depth);
			}
			Console.WriteLine("-------------------------------------------");


		}
		
	}

}
