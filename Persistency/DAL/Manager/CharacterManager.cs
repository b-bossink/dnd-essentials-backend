using System;
using System.Collections.Generic;
using System.Linq;
using Persistency.Models;

namespace Persistency.DAL.Manager
{
    public class CharacterManager : IDatabaseManager<Character>
    {
        private readonly DatabaseContext _ctx;
        public CharacterManager(DatabaseContext context)
        {
            _ctx = context;
        }

        public int Create(Character character)
        {
            try
            {
                _ctx.Characters.Add(character);
                return _ctx.SaveChanges();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public Character Read(int id)
        {
            try
            {
                return _ctx.Characters.SingleOrDefault(c => c.ID == id);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Character> ReadAll()
        {
            try
            {
                return _ctx.Characters;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Character[0];
            }
        }

        public int Update(Character character)
        {
            var c = _ctx.Characters.SingleOrDefault(c => c.ID == character.ID);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(character);
                return _ctx.SaveChanges(); ;
            }
            return 0;
        }

        public int Delete(int id)
        {
            Character c = _ctx.Characters.SingleOrDefault(c => c.ID == id);
            if (c != null)
            {
                _ctx.Characters.Remove(c);
                return _ctx.SaveChanges();
            }
            return 0;
        }
    }
}

