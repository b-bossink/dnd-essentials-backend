using System;
using System.Collections.Generic;

namespace Models.ViewModel
{
	public class UserViewModel
	{
        public string Username { get; set; }
        public string Emailaddress { get; set; }
        public string Password { get; set; }
    }

    public class GETUserViewModel : UserViewModel
    {
        public int ID { get; set; }
        public ICollection<int> CharacterIDs { get; set; }
        public ICollection<int> CampaignIDs { get; set; }
    }
}

