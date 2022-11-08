using System;
namespace Service.CharacterGeneration
{
	public class GenerationService
	{
		private int RollDice(int eyes)
		{
			return new Random().Next(0, eyes);
		}
	}
}

