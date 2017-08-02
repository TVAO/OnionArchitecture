using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Repository.Interfaces;

namespace OnionArchitecture.Repository
{

    /// <summary>
    /// Represents generic repository used to perform CRUD operations in DAL, implemented by all repositories as an abstract class. 
    /// Virtual is used to indicate that default signature in interface is overriden so that CRUD operations are async.
    /// </summary>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly IContext _context;

        // Database context is injected into repository 
        public GenericRepository(IContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dispose the database context.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Creates a given entity asynchronously. 
        /// </summary>
        /// <param name="entity"> Entity to create. </param>
        /// <returns> Id of newly created entity. </returns>
        public virtual async Task<int> CreateAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            if (await _context.SaveChangesAsync() != 1)
            {
                return 0;
            }
            else return result.Entity.Id;
        }

        /// <summary>
        /// Finds the entity with the given id and returns it.
        /// </summary>
        /// <param name="id"> Id of the entity searched for. </param>
        /// <returns> Entity with the given id.</returns>
        public virtual async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Updates the entity with a matching id, to the given entity.
        /// </summary>
        /// <param name="entity">The new version of the entity to update. </param>
        /// <returns> Boolean indicating if the operation was successful, true if success. </returns>
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Deletes the entity with the given id if it exists.
        /// </summary>
        /// <param name="id"> Id of the entity to delete. </param>
        /// <returns> Boolean indicating if the operation was successful, true if success. </returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Set<T>().First(e => e.Id == id);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
