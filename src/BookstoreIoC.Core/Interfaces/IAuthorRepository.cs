using BookstoreIoC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreIoC.Core.Interfaces
{
    public interface IAuthorRepository : IRepository<Author,int>, IRepositoryAsync<Author, int>
    { 
        Author GetByName(string name);
    }
}
