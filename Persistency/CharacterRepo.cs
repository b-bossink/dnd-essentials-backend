using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository;
using Repository.Connection;

namespace Repository
{
    public class CharacterRepo : ICRUDRepo<Character>
    {
        private readonly string _connection;
        public CharacterRepo(string connectionString)
        {
            _connection = connectionString;
        }

        public async Task<int> Create(Character character)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    character.Campaigns = await RepoHelper.PopulateProperties<Campaign>(character.Campaigns, ctx.Campaigns);
                    ctx.Characters.Add(character);
                    return await ctx.SaveChangesAsync();
                }
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
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    return await ctx.Characters.Include(c => c.Campaigns).SingleOrDefaultAsync(c => c.ID == id);
                }
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
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    return await ctx.Characters.Include(c => c.Campaigns).ToListAsync();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Character[0];
            }
        }

        public async Task<int> Update(Character character)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    ctx.Set<Character>().AddOrUpdate(character);
                    return await ctx.SaveChangesAsync();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    Character c = await ctx.Characters.SingleOrDefaultAsync(c => c.ID == id);
                    if (c != null)
                    {
                        ctx.Characters.Remove(c);
                        return await ctx.SaveChangesAsync();
                    }
                    return 0;
                }
            } catch (Exception e)
            {
                return 0;
            }
        }
    }
}

