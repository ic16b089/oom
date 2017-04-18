using System; 
using System.Linq;


namespace Task4_Reincarnation
{


	class MainClass
	{
		public static void Main(string[] args)
		{
			var my_divers_logbook = new[]
			{
				new Divers_Logbook(1, "Hawaii", 27, Dive_Type.Oxygen_Dive),
				new Divers_Logbook(2, "Island", 34, Dive_Type.Nitrox_Dive),
				new Divers_Logbook(3, "Egypt", 22, Dive_Type.Oxygen_Dive),
				new Divers_Logbook(4, "Bahamas", 14, Dive_Type.Free_Dive),
				new Divers_Logbook(5, "Maledives", 32, Dive_Type.Oxygen_Dive)

			};

			Console.WriteLine("\nRecords of Diver's Logbook:\n");
			foreach (var my_dlb_idx in my_divers_logbook) {

				Console.WriteLine("{0}\t{1}\t{2}m\t{3}", 
				                  my_dlb_idx.Dive_Number,
				                  my_dlb_idx.Dive_Location, 
				                  my_dlb_idx.Dive_Depth,
				                  my_dlb_idx.Dive_Type);

			}


			var all_dive_locations = my_divers_logbook.Select(x => x.Dive_Location).OrderBy(x => x);
			          Console.WriteLine();
			          Console.WriteLine("\nall Dive Locations:\n");
			         foreach (var x in all_dive_locations) Console.WriteLine(x);

			Console.WriteLine("\n\nNumber of Records in Diver's Logbook: {0}\n\n", my_divers_logbook.Length);

			var my_divers_card = new Divers_Card(my_divers_logbook.Length, "Robert", "active");
			Console.WriteLine("Information from Diver's Card: \t{0}\t{1}\t{2}\n\n", my_divers_card.ActualNumberOfDives,
			                  														my_divers_card.DiversName,
			                  														my_divers_card.DiversStatus);

			Console.WriteLine("Updating one record in Divers Logbook");
			foreach (var my_dlb_idx in my_divers_logbook)
			{
				if ((my_dlb_idx.Dive_Number == 3) && (my_dlb_idx.Dive_Depth < 20))
				{
					my_dlb_idx.Update_Dive(6, "Dubai", 32, Dive_Type.Oxygen_Dive);
				}
			}


			Console.WriteLine("\nRecords of Diver's Logbook:\n");
			foreach (var my_dlb_idx in my_divers_logbook)
			{

				Console.WriteLine("{0}\t{1}\t{2}m\t{3}",
								  my_dlb_idx.Dive_Number,
								  my_dlb_idx.Dive_Location,
								  my_dlb_idx.Dive_Depth,
								  my_dlb_idx.Dive_Type);

			}
			Console.WriteLine("\n\n");


			Divers_Loogbook_Serialisation.Run(my_divers_logbook);

		}
	}
}
