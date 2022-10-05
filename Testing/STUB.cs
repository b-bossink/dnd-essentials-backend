using System;
using Persistency.Models;
using System.Collections.Generic;
using Persistency.DAL.Manager;
using System.Linq;
using System.Collections.ObjectModel;

namespace Testing
{
	public class STUB<T> : IDatabaseManager<T> where T : DatabaseEntity
    {
        protected readonly List<T> _data;

        public STUB(List<T> testData)
        {
            _data = testData;
        }

        public int Create(T value)
        {
            int before = _data.Count();
            _data.Add(value);
            int after = _data.Count();
            return after - before;
        }

        public int Delete(int id)
        {
            return _data.RemoveAll(e => e.ID == id);
        }

        public T Read(int id)
        {
            return _data.SingleOrDefault(e => e.ID == id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _data;
        }

        public int Update(T value)
        {
            int index = _data.IndexOf(_data.SingleOrDefault(e => e.ID == value.ID));
            if (index == -1)
            {
                return index;
            }

            _data[index] = value;
            return 1;
        }

        public ReadOnlyCollection<T> GetData()
        {
            return _data.AsReadOnly();
        }
    }
}

