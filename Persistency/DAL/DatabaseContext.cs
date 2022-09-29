using System;
using System.Data.Entity;
using Persistency.Models;

namespace Persistency.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DatabaseContext() : base(@"Server=localhost,1433;Database=DnDEssentials;User Id=SA;Password=db80551Nk!") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }
}

