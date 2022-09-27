using System;
namespace CampaignData.Models
{
    public class Character
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Race { get; private set; }

        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Consitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }

        public Character(int id, string name, string clazz, string race, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            ID = id;
            Name = name;
            Class = clazz;
            Race = race;

            Strength = strength;
            Dexterity = dexterity;
            Consitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }
    }
}

