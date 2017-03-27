using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookApi.Models;

namespace BookApi.Controllers
{
    public class BooksController : ApiController
    {
        private IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Books
        [HttpGet]
        public IQueryable<Book> GetBooks()
        {
            return _repository.GetAll();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.Add(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }
    }
}