using System;
namespace Task4_Reincarnation
{
	/// <summary>
	/// Divers card.
	/// stores only the actual number of dives made an divers name
	/// </summary>
	public class Divers_Card
	{
		public Divers_Card(decimal actual_number_of_dives, string divers_name, string divers_status)
		{
			if (actual_number_of_dives <= 0) throw new ArgumentException("Actual Number of Dives must be greater than 0.", nameof(actual_number_of_dives));
			if (string.IsNullOrWhiteSpace(divers_name)) throw new ArgumentException("Divers Name must not be empty.", nameof(divers_name));
			if (string.IsNullOrWhiteSpace(divers_status)) throw new ArgumentException("Divers Name must not be empty.", nameof(divers_status));

			ActualNumberOfDives = actual_number_of_dives;
			DiversName = divers_name;
			DiversStatus = divers_status;
		}

		/// <summary>
		/// Gets the actual number of dives.
		/// </summary>
		/// <value>The actual number of dives.</value>
		public decimal ActualNumberOfDives { get; }

		/// <summary>
		/// Gets the name of the divers.
		/// </summary>
		/// <value>The name of the divers.</value>
		public string DiversName { get; }

		/// <summary>
		/// Gets the divers status.
		/// active or passive
		/// </summary>
		/// <value>The divers status.</value>
		public string DiversStatus { get;}


	}
}
