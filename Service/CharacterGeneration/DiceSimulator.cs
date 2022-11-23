using System;
namespace Service.CharacterGeneration
{
    public class DiceSimulator : IRandomizer
    {
        private readonly Die[] _dice;
        public DiceSimulator(Die[] dice)
        {
            _dice = dice;
        }

        public DiceSimulator(Die die)
        {
            _dice = new Die[] { die };
        }

        public int Randomize()
        {
            var res = 0;
            var random = new Random();
            foreach (var die in _dice)
            {
                res += random.Next(1, die.Eyes + 1);
            }
            return res;
        }
    }
}

