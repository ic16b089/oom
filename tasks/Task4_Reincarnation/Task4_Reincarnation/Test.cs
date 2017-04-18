using NUnit.Framework;


namespace Task4_Reincarnation
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
				var x = new Divers_Logbook(-1, "Hawaii", 27, Dive_Type.Oxygen_Dive);
			});
		}
		public void CannotCreateNewDiveWithoutDiveLocation()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, "", 27, Dive_Type.Oxygen_Dive);
			});
		}

		[Test]
		public void CannotUpdateDiversLogbookWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, "Hawaii", 27, Dive_Type.Oxygen_Dive);
				x.Update_Dive(-4, "Hawaii", 27, Dive_Type.Oxygen_Dive);
			});
		}
		[Test]
		public void CannotUpdateDiversLogbookWithoutDiveLocation()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, "Hawaii", 27, Dive_Type.Oxygen_Dive);
				x.Update_Dive(4, "", 27, Dive_Type.Oxygen_Dive);
			});
		}
		[Test]
		public void CannotUpdateDiversLogbookWithNegativeDepth()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Logbook(1, "Hawaii", 27, Dive_Type.Oxygen_Dive);
				x.Update_Dive(4, "Hawaii", -27, Dive_Type.Oxygen_Dive);
			});
		}
		[Test]
		public void CannotInsertNumberOfDivesInDiversCardWithNegativeDiveNumber()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Card(-2, "Robert", "active");
			});
		}
		[Test]
		public void CannotInsertInDiversCardWithoutDiversName()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Card(2, "", "active");
			});
		}
		[Test]
		public void CannotInsertInDiversCardWithoutDiversStatus()
		{
			Assert.Catch(() =>
			{
				var x = new Divers_Card(2, "Robert", "");
			});
		}

	}
}
