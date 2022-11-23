using System;
namespace Models
{
	public class Notification
	{
		public string Title { get; private set; }
		public string Message { get; private set; }
		public Notification(string title, string message)
		{
			Title = title;
			Message = message;
		}

		public static Notification CharacterAddedToCampaign(string campaignOwnerName, string characterName, string campaignName)
			=> new Notification("Character added to campaign", $"Your character '{characterName}' has been added to '{campaignName}' by '{campaignOwnerName}'!");
	}
}

