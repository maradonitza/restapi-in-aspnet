using BookstoreApi.Core.Repositories;
using System;

namespace BookstoreApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}