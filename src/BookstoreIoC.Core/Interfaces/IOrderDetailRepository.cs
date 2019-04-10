using BookstoreIoC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreIoC.Core.Interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail,int>, IRepositoryAsync<OrderDetail, int>
    {
    }
}
