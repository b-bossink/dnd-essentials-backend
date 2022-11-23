using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Service.CharacterGeneration
{
	public class Stats
	{
        public Stat Strength { get; private set; }
        public Stat Dexterity { get; private set; }
        public Stat Constitution { get; private set; }
        public Stat Intelligence { get; private set; }
        public Stat Wisdom { get; private set; }
        public Stat Charisma { get; private set; }

        private Stats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = new Stat(strength);
            Dexterity = new Stat(dexterity);
            Constitution = new Stat(constitution);
            Intelligence = new Stat(intelligence);
            Wisdom = new Stat(wisdom);
            Charisma = new Stat(charisma);
        }

        public static Stats Random(IRandomizer randomizer)
        {
            return new Stats
            (
                randomizer.Randomize(),
                randomizer.Randomize(),
                randomizer.Randomize(),
                randomizer.Randomize(),
                randomizer.Randomize(),
                randomizer.Randomize()
            );
        }
    }

    public class Stat
    {
        public int Value { get; set; }
        public int Bonus { get; set; }
        public int Total { get
            {
                return Value + Bonus;
            }
        }

        public Stat(int value)
        {
            Value = value;
        }
    }
}

