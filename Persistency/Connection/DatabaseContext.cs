using System;
using System.Configuration;
using System.Data.Entity;
using Models;

namespace Repository.Connection
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public DatabaseContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }
}

