using BookstoreApi.Core;
using BookstoreApi.Core.Repositories;
using BookstoreApi.Persistence.Repositories;

namespace BookstoreApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookstoreContext _context;

        public UnitOfWork(BookstoreContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}