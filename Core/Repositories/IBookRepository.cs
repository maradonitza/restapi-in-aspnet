using BookstoreApi.Core.Domain;
using System.Collections.Generic;

namespace BookstoreApi.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetMostExpensiveBooks(int count);
        IEnumerable<Book> GetBooksWithAuthors(int pageIndex, int pageSize);
    }
}