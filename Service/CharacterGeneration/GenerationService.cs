using System;
using System.Threading.Tasks;
using DnD_API_Adapter;
using Models;

namespace Service.CharacterGeneration
{
	public class GenerationService
	{
		private readonly IDNDClient _client;
		public IRandomizer Randomizer { private get; set; }
		public GenerationService(IDNDClient client, IRandomizer randomizer)
		{
			_client = client;
			Randomizer = randomizer;
		}

		public async Task<Stats> Generate(string raceName)
		{
			var result = Stats.Random(Randomizer);
            var race = await _client.GetRace(raceName);
			if (race == null)
			{
				return null;
			}

            foreach (var ab in race.AbilityBonuses)
			{
				if (ab.AbilityScore.Index.Equals("str"))
				{
					result.Strength.Bonus = ab.Bonus;
				}
				else if (ab.AbilityScore.Index.Equals("dex"))
                {
                    result.Dexterity.Bonus = ab.Bonus;
                }
                else if (ab.AbilityScore.Index.Equals("con"))
                {
                    result.Constitution.Bonus = ab.Bonus;
                }
                else if (ab.AbilityScore.Index.Equals("int"))
                {
                    result.Intelligence.Bonus = ab.Bonus;
                }
                else if (ab.AbilityScore.Index.Equals("wis"))
                {
                    result.Wisdom.Bonus = ab.Bonus;
                }
                else if (ab.AbilityScore.Index.Equals("cha"))
                {
                    result.Charisma.Bonus = ab.Bonus;
                }
            }
			return result;
		}
	}
}

