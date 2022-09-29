using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistency.DAL;
using Persistency.DAL.Manager;
using Persistency.Models;

namespace Testing.UnitTests
{
    [TestClass]
    public class CRUDTests
    {
        [TestMethod]
        public void SaveCharacter()
        {
            // Assign
            IDatabaseManager<Character> manager = new CharacterSTUB();
            bool succes;
            Character c = new Character
            {
                ID = 0,
                Name = "Test Character",
                Race = "Human",
                Class = "Knight",
                Charisma = 1,
                Constitution = 2,
                Dexterity = 3,
                Intelligence = 4,
                Strength = 5,
                Wisdom = 6
            };

            // Act
            succes = manager.Create(c);

            // Assert
            Assert.IsTrue(succes);
        }

        [TestMethod]
        public void UpdateCharacter()
        {
            // Assign
            IDatabaseManager<Character> manager = new CharacterSTUB();
            bool succes;
            Character c = new Character
            {
                ID = 1,
                Name = "Edited Character",
                Race = "Dragonborn",
                Class = "Villager",
                Charisma = 6,
                Constitution = 5,
                Dexterity = 4,
                Intelligence = 3,
                Strength = 2,
                Wisdom = 1
            };

            // Act
            succes = manager.Update(c);

            // Assert
            Assert.IsTrue(succes);
        }
    }
}

