using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbcontext _dbContext;

        public AuthorService(AppDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<bool> CreateAuthor(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask<bool> DeleteAuthor(int id)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
                return false;

            _dbContext.Authors.Remove(author);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask<List<Author>> GetAllAuthor()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async ValueTask<Author> GetByNameAuthor(string name)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(x => x.FullName == name);
        }

        public async ValueTask<Author> UpdateAuthor(int id, Author author)
        {
            var existingAuthor = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAuthor == null)
                return null;

            existingAuthor.FullName = author.FullName;

            _dbContext.Authors.Update(existingAuthor);
            await _dbContext.SaveChangesAsync();

            return existingAuthor;
        }
    }
}
