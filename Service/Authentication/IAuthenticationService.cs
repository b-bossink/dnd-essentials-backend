using System;
using System.Threading.Tasks;
using Models;

namespace Service.Authentication
{
	public interface IAuthenticationService
	{
		public Task<int> Register(User info);
		public Task<int> Update(User user);
		public Task<AuthenticationResponse> Login(string usernameOrEmail, string password);
        public Task<bool> Exists(string usernameOrEmail, string password);
        public Task<int> Delete(int id);
	}
}

