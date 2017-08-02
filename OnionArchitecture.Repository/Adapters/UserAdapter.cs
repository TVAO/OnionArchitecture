using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Models;

namespace OnionArchitecture.Repository.Adapters
{

    /// <summary>
    /// The adapter is used to convert COMMON entities to DataAccessLayer entities, and the other way around.
    /// May not be needed due to AutoMapper in Startup in Web project.
    /// </summary>
    public class UserAdapter : IUserAdapter
    {
        IUserRepository _repo;

        public UserAdapter(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateAsync(User entity)
        {
            var user = entity;//.ToEntity();
            return await _repo.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<User> FindAsync(int id)
        {
            var user = await _repo.FindAsync(id);
            return user; //.ToCommon();
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            var user = entity; //.ToEntity();
            return await _repo.UpdateAsync(user);
        }
    }
}
