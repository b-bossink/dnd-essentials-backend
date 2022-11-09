using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
	public class UserService
	{
		private readonly UserRepo _repo;
        public UserService(UserRepo repo)
        {
            _repo = repo;
        }

        public async Task<User> Get(int id)
        {
            return await _repo.Read(id);
        }

        public async Task<IEnumerable<Character>> GetCharacters(int id)
        {
            return await _repo.ReadCharacters(id);
        }

        public async Task<IEnumerable<Campaign>> GetCampaigns(int id)
        {
            return await _repo.ReadCampaigns(id);
        }
    }
}

