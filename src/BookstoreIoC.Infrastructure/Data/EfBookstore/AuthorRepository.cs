using System;
using System.Collections.Generic;
using System.Text;
using BookstoreIoC.Infrastructure.Data.EfRepository;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookstoreIoC.Infrastructure.Data.EfBookstore
{
    internal class AuthorRepository : EfRepository<Author, int>, IAuthorRepository
    {
        private BookstoreContext Context { get => (BookstoreContext) _DbContext; }
        public AuthorRepository(BookstoreContext dbContext) : base(dbContext)
        {
        }

        public Author GetByName(string name)
        {
            return Context.Authors.Where(a => a.Name.ToUpper() == name.ToUpper()).SingleOrDefault();
        }
    }
}
