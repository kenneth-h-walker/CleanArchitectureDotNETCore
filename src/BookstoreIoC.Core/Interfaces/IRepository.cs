using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreIoC.Core.Interfaces
{
    public interface IRepository<T,TId> : IDisposable where TId : IComparable
    {
        IEnumerable<T> ListAll();
        T GetById(TId id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
