using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Service;

namespace Testing.UnitTests
{
    [TestClass]
    public class CRUDTests
    {
        private static readonly List<Character> characterTestData = new List<Character>() {
            new Character
            {
                ID = 3,
                Name = "John",
                Class = "Bard",
                Race = "Human",
                Charisma = 10,
                Constitution = 11,
                Dexterity = 12,
                Intelligence = 13,
                Strength = 14,
                Wisdom = 15
            },

            new Character
            {
                ID = 4,
                Name = "Sarah",
                Class = "Ranger",
                Race = "Half-elf",
                Charisma = 15,
                Constitution = 14,
                Dexterity = 13,
                Intelligence = 12,
                Strength = 11,
                Wisdom = 10
            },

            new Character
            {
                ID = 5,
                Name = "Denzel",
                Class = "Paladin",
                Race = "Dwarf",
                Charisma = 5,
                Constitution = 7,
                Dexterity = 9,
                Intelligence = 16,
                Strength = 6,
                Wisdom = 21
            }
        };

        [TestMethod]
        public void CreateCharacter()
        {
            // Assign
            var stub = new STUB<Character>(characterTestData);
            CharacterService service = new CharacterService(stub);
            int changed;
            int expected = 1;
            Character c = new Character
            {
                ID = 1,
                Name = "Test Character",
                Race = "Human",
                Class = "Fighter",
                Charisma = 1,
                Constitution = 2,
                Dexterity = 3,
                Intelligence = 4,
                Strength = 5,
                Wisdom = 6
            };

            // Act
            changed = service.Create(c).Result;

            // Assert
            Assert.AreEqual(expected, changed, "Unexpected amount of entries got changed.");
            var updatedData = stub.GetData();
            Assert.AreEqual(c, updatedData[updatedData.Count() - 1], "Newest character added to STUB does not equal character defined beforehand.");
        }

        [TestMethod]
        public void UpdateCharacter()
        {
            // Assign
            var stub = new STUB<Character>(characterTestData);
            CharacterService service = new CharacterService(stub);
            int changed;
            int id = 4;
            int expected = 1;
            Character c = new Character
            {
                ID = id,
                Name = "Edited Character",
                Race = "Dragonborn",
                Class = "Wizard",
                Charisma = 6,
                Constitution = 5,
                Dexterity = 4,
                Intelligence = 3,
                Strength = 2,
                Wisdom = 1
            };

            // Act
            changed = service.Update(c).Result;

            // Assert
            Assert.AreEqual(expected, changed);
            Assert.AreEqual(c, stub.GetData().SingleOrDefault(e => e.ID == id), "Character with given ID does not equal what has been defined before updating, or it doesn't exist.");
        }

        [TestMethod]
        public void ReadCharacter()
        {
            // Assign
            var stub = new STUB<Character>(characterTestData);
            var service = new CharacterService(stub);
            int id = 5;
            Character expected = characterTestData.SingleOrDefault(e => e.ID == id);
            Character result;

            // Act
            result = service.Get(id).Result;

            // Assert
            Assert.IsNotNull(expected, $"Character with id {id} doesn't exist in test data. Make sure it does before testing this method.");
            Assert.AreEqual(expected, result, "Expected character does not equal retrieved character.");
        }

        [TestMethod]
        public void ReadAllCharacters()
        {
            // Assign
            var stub = new STUB<Character>(characterTestData);
            var service = new CharacterService(stub);
            List<Character> expected = characterTestData;
            IEnumerable<Character> result;

            // Act
            result = service.GetAll().Result;

            // Assert
            CollectionAssert.AreEqual(expected, result.ToList(), "Test data does not match retrieved data.");
        }

    }
}

