using System;
using Persistency.Models;
using System.Collections.Generic;
using Persistency.DAL.Service;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Testing
{
	public class STUB<T> : IService<T> where T : DatabaseEntity
    {
        protected readonly List<T> _data;

        public STUB(List<T> testData)
        {
            _data = testData;
        }

        public Task<int> Create(T value)
        {
            int before = _data.Count();
            _data.Add(value);
            int after = _data.Count();
            return Task.FromResult(after - before);
        }

        public Task<int> Delete(int id)
        {
            return Task.FromResult(_data.RemoveAll(e => e.ID == id));
        }

        public Task<T> Read(int id)
        {
            return Task.FromResult(_data.SingleOrDefault(e => e.ID == id));
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            return Task.FromResult(_data.AsEnumerable());
        }

        public Task<int> Update(T value)
        {
            int index = _data.IndexOf(_data.SingleOrDefault(e => e.ID == value.ID));
            if (index == -1)
            {
                return Task.FromResult(index);
            }

            _data[index] = value;
            return Task.FromResult(1);
        }

        public ReadOnlyCollection<T> GetData()
        {
            return _data.AsReadOnly();
        }
    }
}

