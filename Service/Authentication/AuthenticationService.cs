using System;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service.Authentication
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly IAuthenticationRepo _repo;
        public AuthenticationService(IAuthenticationRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> Register(User user)
        {
            return await _repo.Create(user);
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<int> Update(User user)
        {
            return await _repo.Update(user);
        }

        public async Task<bool> Exists(string usernameOrEmail, string password)
        {
            return await _repo.Exists(usernameOrEmail, password);
        }
    }
}

