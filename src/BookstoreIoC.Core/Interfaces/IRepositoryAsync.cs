using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreIoC.Core.Interfaces
{
    public interface IRepositoryAsync<T,TId> : IDisposable where TId : IComparable
    {
        Task<List<T>> ListAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
