using DnD_API_Adapter;
using DnD_API_Adapter.APIModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.IntegrationTests
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
			// Arrange
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
	}
}

