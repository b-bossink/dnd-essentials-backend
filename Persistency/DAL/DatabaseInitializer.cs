using System;
using Persistency.Models;

namespace Persistency.DAL
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Characters.Add(new Character
            {
                Name = "some name",
                Class = "some class",
                Race = "some race",
                Strength = 1,
                Dexterity = 2,
                Constitution = 3,
                Intelligence = 4,
                Wisdom = 5,
                Charisma = 6
            });
        }
    }
}

