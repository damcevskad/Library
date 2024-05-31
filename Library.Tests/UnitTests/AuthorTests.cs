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
    public class AuthorTests
    {
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;
        private readonly AuthorService _authorService;

        public AuthorTests()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _authorService = new AuthorService(_mockAuthorRepository.Object);
        }

        [Fact]
        public void GetAlAuthors_ShouldReturnAllAuthors()
        {
            var authors = new List<Author>
            {
                new Author { Id = 1, FirstName = "FirstName", LastName = "LastName", Nationality = "MK"},
                new Author { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Nationality = "EN"},
            };
            _mockAuthorRepository.Setup(repo => repo.GetAllAuthors()).Returns(authors);

            var result = _authorService.GetAllAuthors();

            Assert.Equal(authors, result);
        }

        [Fact]
        public void GetAuthorById_ShouldReturnAuthor_WhenAuthorExists()
        {
            var author = new Author { Id = 1, FirstName = "FirstName", LastName = "LastName", Nationality = "MK" };
            _mockAuthorRepository.Setup(repo => repo.GetAuthorById(1)).Returns(author);

            var result = _authorService.GetAuthorById(1);

            Assert.Equal(author, result);
        }

        [Fact]
        public void CreateAuthor_ShouldCallRepositoryCreateAuthor()
        {
            var author = new Author { Id = 1, FirstName = "FirstName", LastName = "LastName", Nationality = "MK" };

            _authorService.CreateAuthor(author);

            _mockAuthorRepository.Verify(repo => repo.CreateAuthor(author), Times.Once);
        }
    }
}
