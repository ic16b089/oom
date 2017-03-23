using System;
using NUnit.Framework;
using Task4;

namespace Task4
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void SimpleTest()
		{
			Assert.IsTrue(1 == 1);
		}

		[Test]
		public void CannotCreateNewDiveWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(-4, 1, 2, "Dummy", 23);
			});
		}

		[Test]
		public void CannotUpdateDiversLogbookWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(-1, 1, 2, "Dummy", 23);
				x.Update_Divers_Logbook(-4, "Island_Update", 25);
			});
		}
		[Test]
		public void CannotUpdateDiversLogbookWithoutDiveLocation()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(-1, 1, 2, "Dummy", 23);
				x.Update_Divers_Logbook(2, "", 25);
			});
		}
		[Test]
		public void CannotUpdateDiversLogbookWithNegativeDepth()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(-1, 2, 2, "Dummy", 23);
				x.Update_Divers_Logbook(2, "Island_Update", -25);
			});
		}
		[Test]
		public void CannotInsertNumberOfDivesWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Card(-13);
			});
		}
		[Test]
		public void CannotPrintNumberOfDivesWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Card(13).Print_Number_of_Dives(-1);
			});
		}
		public void CannotCallGetStringWithoutStringArgument()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, 1, 2, "Dummy", 23).get_string("");
			});
		}
		public void CannotCallGetDecimalWithoutStringArgument()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, 1, 2, "Dummy", 23).get_decimal("");
			});
		}






}
}
