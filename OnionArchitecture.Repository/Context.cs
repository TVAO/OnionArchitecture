using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Models;

namespace OnionArchitecture.Repository
{

    // This class coordinates EF functionality for the data model 
    public class Context : DbContext, IContext
    {

        public Context()
        {
            
        }

        //public Context(DbContextOptions<Context> options) : base(options)
        public Context(DbContextOptions options) : base(options)
        {
        }

        // Entity part of data model represented as a set (table)
        // Each entity is a row in the table 
        public DbSet<User> Users { get; set; }

        /// <summary>
        ///  Use this method to override default behavior (e.g. table names)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }


    }
}
