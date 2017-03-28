using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookApi.Models;
using BookApi.Controllers;
using System.Threading.Tasks;
using Moq;
using System.Linq;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace BookApi.Tests
{
    [TestClass]
    public class BooksControllerTests
    {
        BooksController booksApi;

        [TestInitialize]
        public void InitializeForTests()
        {
            var repo = new Mock<IBookRepository>();

            booksApi = new BooksController(repo.Object);
        }

        [TestMethod]
        public async Task PostBook_Should_Return_Posted_Book()
        {
            var bookResult = await booksApi.PostBook(new Book { ISBN = "4512321245", Title = "Posted Test Book", Edition = "1st" }) as CreatedAtRouteNegotiatedContentResult<Book>;

            Assert.AreEqual(bookResult.Content.ISBN, "4512321245");
            Assert.AreEqual(bookResult.Content.Title, "Posted Test Book");
            Assert.AreEqual(bookResult.Content.Edition, "1st");
        }
    }
}
