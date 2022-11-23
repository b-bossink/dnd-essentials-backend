using System;
using System.Threading.Tasks;
using DnD_API_Adapter;
using DnD_API_Adapter.APIModel;

namespace Testing
{
	public class MockDNDClient : IDNDClient
	{
        public Task<APINavigationObject.Collection> GetAllOfIndex(string index)
        {
            throw new NotImplementedException();
        }

        public async Task<APIRace> GetRace(string index)
        {
            return new APIRace
            {
                Name = "Dragonborn",
                AbilityBonuses = new APIAbilityBonus[]
                {
                    new APIAbilityBonus
                    {
                        AbilityScore = new APINavigationObject
                        {
                            Index = "str",
                            Name = "STR"
                        },
                        Bonus = 2
                    },
                    new APIAbilityBonus
                    {
                        AbilityScore = new APINavigationObject
                        {
                            Index = "cha",
                            Name = "CHA"
                        },
                        Bonus = 1
                    }
                }
            };
        }
    }
}

