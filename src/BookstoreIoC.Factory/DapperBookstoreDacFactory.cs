using BookstoreIoC.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookstoreIoC.Factory
{
    public class DapperBookstoreDacFactory : IBookstoreDacFactory
    {
        public DapperBookstoreDacFactory()
        {
        }

        public IAuthorRepository CreateAuthorRepository()
        {
            return new Infrastructure.Data.DapperBookstore.AuthorRepository(
                GlobalVars.Instance.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}