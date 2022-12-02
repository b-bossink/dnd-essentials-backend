using DnD_API_Adapter;
using DnD_API_Adapter.APIModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.CharacterGeneration;

namespace Testing.Integration
{
    [TestClass]
	public class DNDAPIConnection
	{
		[TestMethod]
		public void GetAllOfIndex()
		{
			// Arrange
			DNDClient client = new DNDClient();
			APINavigationObject.Collection result;

			// Act
			result = client.GetAllOfIndex("races").Result;

			// Assert
			Assert.IsNotNull(result, "GetAllOfIndex() returned null while it was not expected to.");
		}

		[TestMethod]
		public void GetDragonborn()
		{
			// Assign
			DNDClient client = new DNDClient();
			APIRace dragonborn;
			string raceIndex = "dragonborn";
			string expectedName = "Dragonborn";

			// Act
			dragonborn = client.GetRace(raceIndex).Result;

			// Assert
			Assert.IsNotNull(dragonborn);
			Assert.AreEqual(expectedName, dragonborn.Name, "Expected index did not match actual");
		}

		[TestMethod]
        public void RandomizeByRace()
        {
            // Assign
            var service = new GenerationService(new DNDClient(), new FakeDiceSimulator(3));
            Stats stats;

            // Act
            stats = service.Generate("dragonborn").Result;

            // Assert
            Assert.AreEqual(5, stats.Strength);
            Assert.AreEqual(4, stats.Charisma);
            Assert.AreEqual(3, stats.Constitution);
            Assert.AreEqual(3, stats.Dexterity);
            Assert.AreEqual(3, stats.Intelligence);
            Assert.AreEqual(3, stats.Wisdom);
        }
    }
}

