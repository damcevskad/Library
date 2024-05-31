using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void CreateAuthor(Author author);
        void UpdateAuthor(int id, Author author);
        void DeleteAuthor(int id);
    }
}
