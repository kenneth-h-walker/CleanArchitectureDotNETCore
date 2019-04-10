using BookstoreIoC.Core.Interfaces;
using BookstoreIoC.Infrastructure.Data.EfBookstore;
using System;

namespace BookstoreIoC.Factory
{
    public class EfBookstoreDacFactory : IBookstoreDacFactory
    {
        public EfBookstoreDacFactory()
        {
        }

        public IAuthorRepository CreateAuthorRepository()
        {
            BookstoreContext dbContext = new BookstoreContext();
            IAuthorRepository repository = new AuthorRepository(dbContext);
            return repository;
        }

    }
}
