using System;
using System.Linq;


namespace Task4_Ext_Task6
{
	public static class Divers_Logbook_PullExample
	{
		public static void Run(Divers_Logbook[] items)
		{

			var my_divers_logbook = items[0];

			// using Linq functions like "Select, OrderBy, ..." to generate a sorted list //

			var all_dive_locations = items.Select(x => x.Dive_Location).OrderBy(x => x);

			// NEW 1 - PULL Example on an existing sorted list "all_dive_locations" generated above //

			Console.WriteLine("\n ---------- NEW 1 - PULL Example & Linq Func ** Divers_Logbook_PullExample ----------\n");
			var e = all_dive_locations.GetEnumerator();
			while (e.MoveNext()) Console.WriteLine(">{0}<",e.Current);
			Console.WriteLine("\n ---------- END NEW 1 - PULL Example & Linq Func ** Divers_Logbook_PullExample ----------\n");

			// END NEW //


		}
	}
}
