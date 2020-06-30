using BookstoreApi.Core.Domain;

namespace BookstoreApi.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithBooks(int id);
    }
}