using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// using System.Windows.Forms;
using static System.Console;


namespace Task4_Ext_Task6
{
	public static class Divers_Logbook_Task_62
	{
		public static void Run(Divers_Logbook[] items)
		{

			var my_divers_logbook = items[0];


			Console.WriteLine("\n ---------- NEW 2 - Task 6.2 Examples Part 1  ----------\n");
			var tasks = new List<Task<Divers_Logbook>>();
			var all_dive_locations = items.Select(x => x.Dive_Location).OrderBy(x => x);

			foreach (var x in all_dive_locations)
			{
				var task = Task.Run(() =>
									{
										Console.WriteLine("fetched content:  {0}",x);
									}
				                   );

			// tasks.Add(task);
			}
			Console.WriteLine("doing something else ...");
			Console.WriteLine("\n ---------- END NEW 2 - Task 6.2 Examples Part 1 ----------\n");



			Console.WriteLine("\n ---------- NEW 2 - Task 6.2 Examples Part 2  ----------\n");
			var tasks2 = new List<Task<Divers_Logbook>>();
			foreach (var task in tasks.ToArray())
			{
			 	tasks2.Add(
			 		task.ContinueWith(t => { WriteLine($"result is {t.Result}"); return t.Result; })
			 	);
			 }
			Console.WriteLine("\n ---------- END NEW 2 - Task 6.2 Examples Part 2 ----------\n");

		}

	}
}
