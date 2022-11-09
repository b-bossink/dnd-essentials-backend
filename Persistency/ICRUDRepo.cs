using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public interface ICRUDRepo<T> where T : ModelBase
    {
        public Task<IEnumerable<T>> ReadAll();
        public Task<T> Read(int id);
        public Task<int> Create(T value);
        public Task<int> Update(T value);
        public Task<int> Delete(int id);
    }
}

