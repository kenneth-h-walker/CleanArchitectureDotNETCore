using BookstoreIoC.Core.Interfaces;

namespace BookstoreIoC.Factory
{
    public interface IBookstoreDacFactory
    {
        IAuthorRepository CreateAuthorRepository();
    }
}