using System;
namespace Service.CharacterGeneration
{
	public class Die
	{
		public readonly static Die D20 = new Die(20, "D20");
        public readonly static Die D12 = new Die(12, "D12");
        public readonly static Die D10 = new Die(10, "D10");
        public readonly static Die D8 = new Die(8, "D8");
        public readonly static Die D6 = new Die(6, "D6");
        public readonly static Die D4 = new Die(4, "D4");
		public readonly static Die[] all = new Die[] { D20, D12, D10, D8, D6, D4 };

        public int Eyes { get; private set; }
		public string Name { get; private set; }

		public Die(int eyes, string name)
		{
			Eyes = eyes;
			Name = name;
		}
	}
}

