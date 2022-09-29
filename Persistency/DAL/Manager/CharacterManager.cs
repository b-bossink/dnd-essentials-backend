using System;
using System.Collections.Generic;
using System.Linq;
using Persistency.Models;

namespace Persistency.DAL.Manager
{
    public class CharacterManager : IDatabaseManager<Character>
    {
        private readonly DatabaseContext ctx;
        public CharacterManager(DatabaseContext context)
        {
            ctx = context;
        }

        public bool Create(Character character)
        {
            try
            {
                ctx.Characters.Add(character);
                return ctx.SaveChanges() > 0;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Character Read(int id)
        {
            try
            {
                return ctx.Characters.SingleOrDefault(c => c.ID == id);
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
                return ctx.Characters;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Character[0];
            }
        }

        public bool Update(Character character)
        {
            var c = ctx.Characters.SingleOrDefault(c => c.ID == character.ID);
            if (c != null)
            {
                ctx.Entry(c).CurrentValues.SetValues(character);
                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Character c = ctx.Characters.SingleOrDefault(c => c.ID == id);
            if (c != null)
            {
                ctx.Characters.Remove(c);
                return ctx.SaveChanges() > 0;
            }
            return false;
        }
    }
}

