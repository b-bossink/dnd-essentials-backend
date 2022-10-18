using System;
using Newtonsoft.Json;

namespace DnD_API_Adapter.APIModel
{
    public class APIRace
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ability_bonuses")]
        public APIAbilityBonus[] AbilityBonuses { get; set; }
    }
}

