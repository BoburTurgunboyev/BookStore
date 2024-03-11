using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.BookServices
{
    public interface IBookService
    {
        public ValueTask<bool> CreateBook(Book book);
        public ValueTask<Book> UpdateBook(int id, Book book);
        public ValueTask<bool> DeleteBook(int id);
        public ValueTask<Book> GetByNameBook(string name);
        public ValueTask<List<Book>> GetAllBook();

    }
}
