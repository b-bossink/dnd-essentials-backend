using System;
using Newtonsoft.Json;

namespace DnD_API_Adapter.APIModel
{
	public class APIAbilityBonus
	{
        [JsonProperty(PropertyName = "ability_score")]
        public APINavigationObject AbilityScore { get; set; }
		public int Bonus { get; set; }
	}
}

