using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
	public class CharacterService : ICRUDService<Character>
	{
		private readonly ICRUDRepo<Character> _repo;
		public CharacterService(ICRUDRepo<Character> repo)
		{
			_repo = repo;
		}

        public async Task<Character> Get(int id)
        {
            return await _repo.Read(id);
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            return await _repo.ReadAll();
        }

        public async Task<int> Create(Character value)
        {
            return await _repo.Create(value);
        }

        public async Task<int> Update(Character value)
        {
            return await _repo.Update(value);
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}

