using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.CharacterGeneration;

namespace Testing.Unit
{
	[TestClass]
	public class StatGenerationTests
	{
		[TestMethod]
		public void AbilityBonus()
		{
			// Assign
			var service = new GenerationService(new MockDNDClient(), new FakeDiceSimulator(3));
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

