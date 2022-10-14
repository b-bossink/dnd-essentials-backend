using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Service
{
	public interface IService<T> where T : ModelBase
	{
		public Task<T> Get(int id);

		public Task<IEnumerable<T>> GetAll();

		public Task<int> Create(T value);

		public Task<int> Update(T value);

		public Task<int> Delete(int id);
	}
}

