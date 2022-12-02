using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository.Connection;

namespace Repository
{
    public class UserRepo : ICRUDRepo<User>
    {
        private readonly string _connection;
        public UserRepo(string connectionString)
        {
            _connection = connectionString;
        }

        public async Task<int> Create(User user)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                ctx.Users.Add(user);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int id)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                User u = await ctx.Users.SingleOrDefaultAsync(u => u.ID == id);
                if (u != null)
                {
                    ctx.Users.Remove(u);
                    return await ctx.SaveChangesAsync();
                }
            }
            return 0;
        }

        public async Task<bool> Exists(string usernameOrEmail, string password)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                User u = await ctx.Users.SingleOrDefaultAsync(u => (u.Username.Equals(usernameOrEmail) ||
                    u.Emailaddress.Equals(usernameOrEmail)) && u.Password.Equals(password));

                return u != null;
            }
        }

        public async Task<User> Read(int id)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                return await ctx.Users.Include(u => u.Characters).Include(u => u.Campaigns).SingleOrDefaultAsync(u => u.ID == id);
            }
        }

        public async Task<User> Read(string username)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                return await ctx.Users.Include(u => u.Characters).Include(u => u.Campaigns).SingleOrDefaultAsync(u => u.Username == username);
            }
        }

        public async Task<User> Read(string usernameOrEmail, string password)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                return await ctx.Users.Include(u => u.Characters).Include(u => u.Campaigns).SingleOrDefaultAsync(u => ( u.Username == usernameOrEmail || u.Emailaddress == usernameOrEmail ) && u.Password == password);
            }
        }

        public async Task<IEnumerable<Character>> ReadCharacters(int id)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                var chars = await ctx.Characters.Where(c  => c.UserId == id).Include(c => c.Campaigns).ToListAsync();
                return chars;
            }
        }

        public async Task<IEnumerable<Campaign>> ReadCampaigns(int id)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                var camps = await ctx.Campaigns.Where(c => c.UserId == id).Include(c => c.Characters).ToListAsync();
                return camps;
            }
        }

        public async Task<IEnumerable<User>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(User user)
        {
            throw new NotImplementedException();
        }

        
    }
}

