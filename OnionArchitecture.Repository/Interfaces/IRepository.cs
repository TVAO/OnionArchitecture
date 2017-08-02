using System;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        Task<int> CreateAsync(T entity);
        Task<T> FindAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
