using System;
using System.Collections.Generic;

namespace Models
{
	public class User : ModelBase
	{
		public string Username { get; set; }
		public string Emailaddress { get; set; }
		public string Password { get; set; }
		public virtual ICollection<Character> Characters { get; set; }
		public virtual ICollection<Campaign> Campaigns { get; set; }
	}

	public class UserInfo
    {
        public string Username { get; set; }
        public string Emailaddress { get; set; }
    }
}

