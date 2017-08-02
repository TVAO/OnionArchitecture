using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Repository.Models;

namespace OnionArchitecture.Repository
{
    // EF creates an empty database that is populated with test (seed) data in this class
    public static class DbInitializer
    {

        // Checks if there is any data in db, otherwise assumes db is new and needs to be seeded with test data 
        // Uses arrays instead of List<T> for performance 
        public static async void Initialize(Context context)
        {
            //await context.Database.EnsureCreatedAsync();
            context.Database.EnsureCreated();

            // Look for any entity data
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            var users = new User[]
            {
                new User{ Name = "Thor", Alias = "TO", CreatedOn = DateTime.Now, IsHero = true }, 
                new User{ Name = "Dennis", Alias = "DT", CreatedOn = DateTime.Now, IsHero = false} 
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }

    }
}
