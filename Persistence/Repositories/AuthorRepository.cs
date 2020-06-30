using BookstoreApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookstoreApi.Core.Repositories;

namespace BookstoreApi.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookstoreContext context) : base(context)
        {
        }

        public Author GetAuthorWithBooks(int id)
        {
            return BookstoreContext.Authors.Include(a => a.Books).SingleOrDefault(a => a.Id == id);
        }

        public BookstoreContext BookstoreContext
        {
            get { return Context as BookstoreContext; }
        }
    }
}