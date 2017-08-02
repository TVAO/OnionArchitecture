using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Repository.Tests
{

    /// <summary>
    /// Used to test repository without actually connecting to the database.
    /// Link: https://docs.efproject.net/en/latest/miscellaneous/testing.html 
    /// </summary>
    public class TestUtility
    {
        public static DbContextOptions<Context> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase()
                    .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
