using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
	public class CRUDService<T> : ICRUDService<T> where T : ModelBase
	{
        protected readonly ICRUDRepo<T> _repo;
        public CRUDService(ICRUDRepo<T> repo)
        {
            _repo = repo;
        }
        public async Task<int> Create(T value)
        {
            return await _repo.Create(value);
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            return await _repo.Read(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repo.ReadAll();
        }

        public async Task<int> Update(T value)
        {
            return await _repo.Update(value);
        }
    }
}

