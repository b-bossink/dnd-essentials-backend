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
			Assert.AreEqual(5, stats.Strength.Total);
			Assert.AreEqual(4, stats.Charisma.Total);
            Assert.AreEqual(3, stats.Constitution.Total);
            Assert.AreEqual(3, stats.Dexterity.Total);
            Assert.AreEqual(3, stats.Intelligence.Total);
            Assert.AreEqual(3, stats.Wisdom.Total);
        }
	}
}

