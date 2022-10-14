using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
	public class CampaignService : IService<Campaign>
	{
		private readonly IRepo<Campaign> _repo;
		public CampaignService(IRepo<Campaign> repo)
		{
			_repo = repo;
        }

        public async Task<Campaign> Get(int id)
        {
            return await _repo.Read(id);
        }

        public async Task<IEnumerable<Campaign>> GetAll()
        {
            return await _repo.ReadAll();
        }

        public async Task<int> Create(Campaign value)
        {
            return await _repo.Create(value);
        }

        public async Task<int> Update(Campaign value)
        {
            return await _repo.Update(value);
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}

