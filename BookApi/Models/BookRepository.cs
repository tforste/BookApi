using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookApi.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Book GetById(int id);
        Task Add(Book book);
    }

    public class BookRepository : IBookRepository
    {
        private BookApiContext db = new BookApiContext();

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await db.Books.ToArrayAsync();
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