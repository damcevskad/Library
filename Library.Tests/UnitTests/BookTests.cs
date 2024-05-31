using Library.Data.Entities;
using Library.Data.Interfaces;
using Library.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.UnitTests
{
    public class BookTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly BookService _bookService;

        public BookTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockBookRepository.Object);
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Title", Genre = "Genre", AuthorId = 1 },
                new Book { Id = 2, Title = "Title2", Genre = "Genre2", AuthorId = 2 },
            };
            _mockBookRepository.Setup(repo => repo.GetAllBooks()).Returns(books);

            var result = _bookService.GetAllBooks();

            Assert.Equal(books, result);
        }

        [Fact]
        public void GetBookById_ShouldReturnBook_WhenBookExists()
        {
            var book = new Book { Id = 1, Title = "Title", Genre = "Genre", AuthorId = 1 };
            _mockBookRepository.Setup(repo => repo.GetBookById(1)).Returns(book);

            var result = _bookService.GetBookById(1);

            Assert.Equal(book, result);
        }

        [Fact]
        public void CreateBook_ShouldCallRepositoryCreateBook()
        {
            var book = new Book { Id = 1, Title = "Title", Genre = "Genre", AuthorId = 1 };

            _bookService.CreateBook(book);

            _mockBookRepository.Verify(repo => repo.CreateBook(book), Times.Once);
        }
    }
}
