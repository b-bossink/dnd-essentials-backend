using System;
using System.Configuration;
using System.Data.Entity;
using Persistency.Models;

namespace Persistency.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DatabaseContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }
}

