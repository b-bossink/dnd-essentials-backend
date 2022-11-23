using System;
using Models;

namespace Repository.Event
{
	public class CharacterEventArgs : EventArgs
	{
		public Character character;
		public CharacterEventArgs(Character character)
		{
			this.character = character;
		}
	}

    public class AddCharacterToCampaignArgs : CharacterEventArgs
    {
		public bool success;
		public Campaign campaign;
        public AddCharacterToCampaignArgs(Character character, Campaign campaign, bool success) : base(character)
        {
			this.campaign = campaign;
			this.success = success;
        }
    }
}

