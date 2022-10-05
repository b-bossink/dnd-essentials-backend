using System;
using System.Collections.Generic;
using System.Data.Entity;
using Persistency.Models;

namespace Persistency.DAL.Manager
{
    public interface IDatabaseManager<T> where T : DatabaseEntity
    {
        public IEnumerable<T> ReadAll();
        public T Read(int id);
        public int Create(T value);
        public int Update(T value);
        public int Delete(int id);
    }
}

