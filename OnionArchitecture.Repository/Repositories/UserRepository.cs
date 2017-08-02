using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Models;

namespace OnionArchitecture.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(IContext context) : base(context)
        {
        }

    }
}
