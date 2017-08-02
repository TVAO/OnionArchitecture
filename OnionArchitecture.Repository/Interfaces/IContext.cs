using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Repository.Models;
using Remotion.Linq.Clauses;

namespace OnionArchitecture.Repository.Interfaces
{
    public interface IContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken)); // TODO what is this?
        DbSet<T> Set<T>() where T : class;
    }
}
