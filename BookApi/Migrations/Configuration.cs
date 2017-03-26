namespace BooksApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookApi.Models.BookApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookApi.Models.BookApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Books.AddOrUpdate(x => x.Id,
                new Book() { Id = 1, ISBN = "1491939109", Title = "Raspberry Pi Cookbook", Edition = "2nd" },
                new Book() { Id = 2, ISBN = "1602399816", Title = "Little Red Book of Fly Fishing", Edition = "1st" },
                new Book() { Id = 3, ISBN = "0449813223", Title = "The Inheritance Cycle", Edition = "Slp Rep" }
            );
        }
    }
}