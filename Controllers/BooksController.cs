using AutoMapper;
using BookstoreApi.Core;
using BookstoreApi.Core.Domain;
using BookstoreApi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpGet]
        public IHttpActionResult GetBooks([FromUri] string sort = "")
        {
            var books = _unitOfWork.Books.GetBooksWithAuthors(1, 10, sort);

            var mappedBooks = Mapper.Map<IEnumerable<Book>, IEnumerable<BookReadDto>>(books);
            return Ok(mappedBooks);
        }

        // GET: api/books/paging
        [HttpGet]
        [Route("api/books/paging/{pageNumber=}/{pageSize=}/{sort=}")]
        // [Route("api/books/paging")]
        public IHttpActionResult GetBooksWithCustomPaging([FromUri] int pageNumber = 1, [FromUri] int pageSize = 10, [FromUri] string sort = "")
        {
            var books = _unitOfWork.Books.GetBooksWithAuthors(pageNumber, pageSize, sort);

            var mappedBooks = Mapper.Map<IEnumerable<Book>, IEnumerable<BookReadDto>>(books);
            return Ok(mappedBooks);
        }

        // GET: api/books/5
        [HttpGet]
        [Route("api/Books/{id}")]
        public IHttpActionResult LoadBook(int id)
        {
            var book = _unitOfWork.Books.GetAll().Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                var mappedBook = Mapper.Map<Book, BookReadDto>(book);
                return Ok(mappedBook);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //[Route("api/Books/Test/{id}")]
        //public int Test(int id)
        //{
        //    return id;
        //}

        // POST: api/books
        public IHttpActionResult Post([FromBody] BookUpdateDto book)
        {
            var bookToInsert = Mapper.Map<Book>(book);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _unitOfWork.Books.Add(bookToInsert);
            _unitOfWork.Complete();
            return StatusCode(HttpStatusCode.Created);
        }


        // PUT: api/books/5
        public IHttpActionResult Put(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            var existingBook = _unitOfWork.Books.Find(b => b.Id == id).FirstOrDefault<Book>();

            if (existingBook != null)
            {
                Mapper.Map(bookUpdateDto, existingBook);
                _unitOfWork.Complete();
                return Ok("Record updated successfully");
            }
            else
            {
                return BadRequest("No record found against ID " + id);
            }
        }

        // DELETE: api/books/5
        public IHttpActionResult Delete(int id)
        {
            var book = _unitOfWork.Books.Find(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                _unitOfWork.Books.Remove(book);
                _unitOfWork.Complete();
                return Ok("Book deleted");
            }
            return NotFound();
        }
    }
}
