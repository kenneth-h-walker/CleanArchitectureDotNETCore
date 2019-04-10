using BookstoreIoC.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreIoC.Infrastructure.Data.EfRepository
{
    internal class EfRepository<T,TId> : IRepository<T,TId>, IRepositoryAsync<T, TId> where T:class where TId : IComparable
    {
        private readonly DbContext _dbContext;
        protected DbContext _DbContext => _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(TId id)
        {
            return _DbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            return await _DbContext.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> ListAll()
        {
            return _DbContext.Set<T>().AsEnumerable();
        }

        public virtual async Task<List<T>> ListAllAsync()
        {
            return await _DbContext.Set<T>().ToListAsync();
        }

        public virtual void Add(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task AddAsync(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _DbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _DbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _DbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public virtual void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

    }
}
