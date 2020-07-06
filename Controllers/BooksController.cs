using AutoMapper;
using BookstoreApi.Core;
using BookstoreApi.Core.Domain;
using BookstoreApi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookstoreApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/books
        public IEnumerable<BookReadDto> Get()
        {
            var books = _unitOfWork.Books.GetBooksWithAuthors(1, 10);
            return Mapper.Map<IEnumerable<Book>, IEnumerable<BookReadDto>>(books);
        }

        // GET: api/books/5
        public BookReadDto Get(int id)
        {
            var book = _unitOfWork.Books.GetBooksWithAuthors(1, 10).Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                return Mapper.Map<Book, BookReadDto>(book);
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

        // POST: api/books
        public void Post([FromBody] BookUpdateDto book)
        {
            var bookToInsert = Mapper.Map<Book>(book);
            _unitOfWork.Books.Add(bookToInsert);
            _unitOfWork.Complete();
        }


        // PUT: api/books/5
        public void Put(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            var existingBook = _unitOfWork.Books.Find(b => b.Id == id).FirstOrDefault<Book>();

            if (existingBook != null)
            {
                Mapper.Map(bookUpdateDto, existingBook);
                _unitOfWork.Complete();
            }
        }

        // DELETE: api/books/5
        public void Delete(int id)
        {
            var book = _unitOfWork.Books.Find(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                _unitOfWork.Books.Remove(book);
            }
            _unitOfWork.Complete();
        }


    }
}
