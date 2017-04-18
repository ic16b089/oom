using System;
using Newtonsoft.Json;

namespace Task4_Reincarnation
{


	public interface IUtilities_DL
	{
		void Update_Dive(decimal newdive_number, string newdive_location, decimal newreached_depth, Dive_Type newdive_type);
	}



	/// <summary>
	/// Divers logbook.
	/// stores all the information of each dive
	/// </summary>
	public class Divers_Logbook : IUtilities_DL
	{

		/// <summary>
		/// The p dive number, p_Dive_Location, p_Dive_Depth
		/// all private fields
		/// </summary>
		private string p_Dive_Location;
		private decimal p_Dive_Depth;

		/// <summary>
		/// Constructor
		/// Initializes a new instance of the <see cref="T:Task4_Reincarnation.Divers_Logbook"/> class.
		/// </summary>
		/// <param name="dive_number">Dive number.</param>
		/// <param name="dive_location">Dive location.</param>
		/// <param name="dive_depth">Dive depth.</param>
		/// <param name="dive_type">Dive type.</param>
		[JsonConstructor]
		public Divers_Logbook(decimal dive_number, string dive_location, decimal dive_depth, Dive_Type dive_type)
		{
			if (string.IsNullOrWhiteSpace(dive_location)) throw new ArgumentException("Dive Location must not be empty.", nameof(dive_location));
        	if (dive_depth < 0) throw new ArgumentException("Dive Depth must not be or negative.", nameof(dive_depth));
			Dive_Number = dive_number;
			p_Dive_Location = dive_location;
			p_Dive_Depth = dive_depth;
			Dive_Type = dive_type;
		}


		/// <summary>
		/// Public Property
		/// Gets the dive number.
		/// </summary>
		/// <value>The dive number.</value>
		public decimal Dive_Number { get; private set; }

		/// <summary>
		/// Public Property
		/// Gets the dive location.
		/// </summary>
		/// <value>The dive location.</value>
		public string Dive_Location => p_Dive_Location;

		/// <summary>
		/// Public Property
		/// Gets the dive location.
		/// </summary>
		/// <value>The dive location.</value>
		public decimal Dive_Depth => p_Dive_Depth;

		/// <summary>
		/// Public Property
		/// Gets the dive location.
		/// </summary>
		/// <value>The dive location.</value>
		public Dive_Type Dive_Type { get; private set; }

		/// <summary>
		/// Public Method
		/// Updates the dive.
		/// </summary>
		/// <param name="newdive_number">Newdive number.</param>
		/// <param name="newdive_location">Newdive location.</param>
		/// <param name="newdive_depth">Newdive depth.</param>
		/// <param name="newdive_type">Newdive type.</param>
		public void Update_Dive(decimal newdive_number, string newdive_location, decimal newdive_depth, Dive_Type newdive_type) 
		{ 
			if (newdive_number < 0) throw new ArgumentException("Dive Depth must not be or negative.", nameof(newdive_number));
			if (string.IsNullOrWhiteSpace(newdive_location)) throw new ArgumentException("Dive Location must not be empty.", nameof(newdive_location));
			if (newdive_depth < 0) throw new ArgumentException("Dive Depth must not be or negative.", nameof(newdive_depth));
			Dive_Number = newdive_number;
			p_Dive_Location = newdive_location;
			p_Dive_Depth = newdive_depth;
			Dive_Type = newdive_type;
			Console.WriteLine("Update_Dive called\n");
		}

	}

}
