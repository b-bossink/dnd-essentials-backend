using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository.Connection;

namespace Repository
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly string _connection;
        public AuthenticationRepo(string connectionString)
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
                User u = await ctx.Users.SingleOrDefaultAsync(u => u.Username.Equals(usernameOrEmail) && u.Password.Equals(password));
                return u != null;
            }
        }

        public async Task<int> Update(User user)
        {
            throw new NotImplementedException();
        }

        
    }
}

