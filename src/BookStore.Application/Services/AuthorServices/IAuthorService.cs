using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.AuthorServices
{
    public interface IAuthorService
    {
        public ValueTask<bool> CreateAuthor(Author author);
        public ValueTask<Author> UpdateAuthor(int id, Author author);
        public ValueTask<bool> DeleteAuthor(int id);
        public ValueTask<Author> GetByNameAuthor(string fullname);
        public ValueTask<List<Author>> GetAllAuthor();
    }
}
