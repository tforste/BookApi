using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookApi.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        Task Add(Book book);
    }

    public class BookRepository : IBookRepository
    {
        private BookApiContext db = new BookApiContext();

        public IQueryable<Book> GetAll()
        {
            return db.Books;
        }

        public Book GetById(int id)
        {
            return db.Books.FirstOrDefault(p => p.Id == id);
        }

        public async Task Add(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
        }

        //// POST: api/Books
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> PostBook(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Books.Add(book);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        //}

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}