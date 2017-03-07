using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task2
{
	public class Divers_Logbook
	{

		/// <summary>
		/// private fields
		/// The m_location.
		/// The m_depth.
		/// </summary>
		private string m_location;
		private decimal m_depth;

		/// <summary>
		/// constructor, creates a new object, the Divers_Logbook.
		/// </summary>
		/// <param name="number"></param>
		public Divers_Logbook(decimal number)
		{
			///Console.WriteLine("Divers_Logbook called");
			if (number < 0) throw new ArgumentException("Dive Number must be given and greater 0.", nameof(number));

			/// <summary>
			///call Insert_Divers_Logbook() with the corresponding Dive_Nr
			/// <summary>
			Insert_Divers_Logbook(number);
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
			Console.WriteLine("Please enter the location: ");
			m_location = Console.ReadLine(); 

			while (repeat)
			{
				Console.WriteLine("Please enter the Depth [in meters]: ");
				string input = Console.ReadLine();

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

			Dive_Nr = newDive_Nr;
			Location = m_location;
			Depth = m_depth;


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
			if (string.IsNullOrWhiteSpace(newDive_Location)) throw new ArgumentException("ISBN must not be empty.", nameof(newDive_Location));
			if (reached_Depth < 0) throw new ArgumentException("Depth must be given and greater 0.", nameof(reached_Depth));
			Dive_Nr = newDive_Nr;
			Location = newDive_Location;
			Depth = reached_Depth;
			///Console.WriteLine("Update_Divers_Logbook called");
		}






		/// <summary>
		/// Main Function
		/// </summary>
		static void Main()
		{
			Console.WriteLine("My first C# Program - OOM Task2");

			/// <summary>
			/// Inserts for example 3 Records into the Divers_Logbook
			/// <summary>
			var Divers_Logbook = new [] 
			{ 
				new Divers_Logbook(1),
				new Divers_Logbook(2),
				new Divers_Logbook(3),
			};


			/// <summary>
			/// Print each Record of the Divers_Logbook
			/// <summary>
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



			/// <summary>
			/// Update for example the Location of the "last minus 1 Record" in the Divers_Logbook
			/// <summary>
			foreach (var c in Divers_Logbook)
			{
				if (c.Dive_Nr == dlb_count-1)
				{
					c.Update_Divers_Logbook(c.Dive_Nr, "Island_Update", c.Depth);
				}
			}



			/// <summary>
			/// Print again each Record of the Divers_Logbook
			/// <summary>
			foreach (var d in Divers_Logbook)
			{
				Console.WriteLine("{0} {1} {2}", d.Dive_Nr, d.Location, d.Depth);
			}
			Console.WriteLine("-------------------------------------------");


		}
		
	}

}
