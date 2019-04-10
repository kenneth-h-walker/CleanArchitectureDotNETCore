using BookstoreIoC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreIoC.Infrastructure.Data.DapperBookstore
{
    internal abstract class DapperRepositoryBase<T, TId> : IRepository<T, TId>, IRepositoryAsync<T, TId> where T : class where TId : IComparable
    {

        protected string ConnectionString { get; }

        public DapperRepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public abstract void Add(T entity);

        public abstract void Delete(T entity);
        public abstract T GetById(TId id);
        public abstract IEnumerable<T> ListAll();
        public abstract void Update(T entity);
        public abstract Task<List<T>> ListAllAsync();
        public abstract Task<T> GetByIdAsync(TId id);
        public abstract Task AddAsync(T entity);
        public abstract Task UpdateAsync(T entity);
        public abstract Task DeleteAsync(T entity);
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
