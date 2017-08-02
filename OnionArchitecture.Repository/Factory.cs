using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Repositories;

namespace OnionArchitecture.Repository
{
    public class Factory : IFactory
    {
        public IUserRepository GetUserRepository()
        {
            var context = new Context();
            context.Database.EnsureCreated();
            return new UserRepository(context);
        }
    }
}
