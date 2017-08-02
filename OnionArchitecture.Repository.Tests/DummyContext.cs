using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnionArchitecture.Repository.Tests
{
    /// <summary>
    /// This class is used to mock the database context and create an in-memory database to test CRUD operations on. 
    /// </summary>
    public class DummyContext : Context
    {
        public DbSet<Dummy> Dummies { get; set; }

        public DummyContext(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

    }
}
