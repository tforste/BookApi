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
        /// <summary>
        /// Gets all Books in the DB
        /// </summary>
        /// <returns>All Books</returns>
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _repository.GetAll();
        }

        // POST: api/Books
        /// <summary>
        /// Posts a book and returns the posted book
        /// </summary>
        /// <param name="book">Book object to be posted</param>
        /// <returns>The newly-posted book</returns>
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