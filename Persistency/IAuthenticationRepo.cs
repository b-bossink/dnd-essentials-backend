using System;
using System.Threading.Tasks;
using Models;

namespace Repository
{
	public interface IAuthenticationRepo
	{
		public Task<int> Create(User user);
		public Task<int> Delete(int id);
		public Task<int> Update(User user);
		public Task<bool> Exists(string usernameOrEmail, string password);
	}
}

