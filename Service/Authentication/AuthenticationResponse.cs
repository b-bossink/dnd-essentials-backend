using System;
using Models;

namespace Service.Authentication
{
	public class AuthenticationResponse
	{
		public bool Success { get; private set; }
		#nullable enable
        public string? Token { get; private set; }
        public UserInfo? UserInfo { get; private set; }

        public AuthenticationResponse(bool success, string? token, User? user)
		#nullable disable
        {
            Success = success;
			Token = token;

            if (user != null)
                UserInfo = new UserInfo(user.ID, user.Username, user.Emailaddress);
		}

    }

    public class UserInfo
    {
        public int ID { get; private set; }
        public string Username { get; private set; }
        public string Emailaddress { get; private set; }
        internal UserInfo(int id, string username, string emailaddress)
        {
            ID = id;
            Username = username;
            Emailaddress = emailaddress;
        }
    }

}

