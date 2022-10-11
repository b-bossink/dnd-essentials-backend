using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Persistency.Models;

namespace Persistency.DAL.Service
{
    public class CharacterService : IService<Character>
    {
        private readonly DatabaseContext _ctx;
        public CharacterService(DatabaseContext context)
        {
            _ctx = context;
        }

        public async Task<int> Create(Character character)
        {
            try
            {
                _ctx.Characters.Add(character);
                return await _ctx.SaveChangesAsync();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<Character> Read(int id)
        {
            try
            {
                return await _ctx.Characters.SingleOrDefaultAsync(c => c.ID == id);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<Character>> ReadAll()
        {
            try
            {
                return await _ctx.Characters.ToListAsync();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Character[0];
            }
        }

        public async Task<int> Update(Character character)
        {
            var c = await _ctx.Characters.SingleOrDefaultAsync(c => c.ID == character.ID);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(character);
                return await _ctx.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            Character c = _ctx.Characters.SingleOrDefault(c => c.ID == id);
            if (c != null)
            {
                _ctx.Characters.Remove(c);
                return await _ctx.SaveChangesAsync();
            }
            return 0;
        }
    }
}

