using BookstoreApi.Core.Domain;
using BookstoreApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookstoreApi.Persistence.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext context)
            : base(context)
        {
        }

        public IEnumerable<Book> GetMostExpensiveBooks(int count)
        {
            return BookstoreContext.Books.OrderByDescending(c => c.Price).Take(count).ToList();
        }

        public IEnumerable<Book> GetBooksWithAuthors(int pageIndex, int pageSize = 10)
        {
            return BookstoreContext.Books
                .Include(c => c.Authors)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public BookstoreContext BookstoreContext
        {
            get { return Context as BookstoreContext; }
        }
    }
}