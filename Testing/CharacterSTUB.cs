using System;
using System.Collections.Generic;
using Persistency.DAL.Manager;
using Persistency.Models;

namespace Testing
{
    public class CharacterSTUB : IDatabaseManager<Character>
    {
        public bool Create(Character value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Character Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Character value)
        {
            throw new NotImplementedException();
        }
    }
}

