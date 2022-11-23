using System;
using Service.CharacterGeneration;

namespace Testing
{
	public class FakeDiceSimulator : IRandomizer
	{
		private readonly int _result;
		public FakeDiceSimulator(int result)
		{
			_result = result;
		}

        public int Randomize()
        {
			return _result;
        }
    }
}

