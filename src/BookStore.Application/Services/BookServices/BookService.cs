using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly AppDbcontext _dbcontext;

        public BookService(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async ValueTask<bool> CreateBook(Book book)
        {
            var bookk = new Book()
            {
                Name = book.Name,
                Price = book.Price,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId
            };
            await _dbcontext.Books.AddAsync(bookk); 
            var result  = await _dbcontext.SaveChangesAsync();
            return result > 0;

        }

        public async ValueTask<bool> DeleteBook(int id)
        {
            var book = await _dbcontext.Books.FirstOrDefaultAsync(x => x.Id == id);
            _dbcontext.Books.Remove(book);
            var result  = await _dbcontext.SaveChangesAsync();
            return result>0;
        }

        public async ValueTask<List<Book>> GetAllBook()
        {
            var books = await _dbcontext.Books.Include(x=>x.Genre).Include(x=>x.Author).ToListAsync();
            return books;
        }

        public async ValueTask<Book> GetByIdBook(int id)
        {
            var book = await _dbcontext.Books.Include(x=>x.Genre).Include(x=>x.Author).FirstOrDefaultAsync(x=>x.Id == id);
            return book;
        }

        public async ValueTask<List<Book>> GetByNameBook(string name)
        {
            var books = await _dbcontext.Books
                .Include(x => x.Genre).Include(x => x.Author)
                .Where(x => x.Name.Contains(name) 
                    || x.Author.FullName.Contains(name) 
                    || x.Genre.Name.Contains(name))
                .ToListAsync();
            return books;
        }

        public async ValueTask<Book> UpdateBook(int id, Book book)
        {
            var bookk = await _dbcontext.Books.FirstOrDefaultAsync(x=>x.Id== id);  
            
            bookk.Name=book.Name;
            bookk.Price=book.Price;
            bookk.AuthorId=book.AuthorId;
            bookk.GenreId=book.GenreId;  

            var result = _dbcontext.Books.Update(bookk);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;

        }
    }
}
