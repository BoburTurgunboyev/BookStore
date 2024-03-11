using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly AppDbcontext _dbContext;

        public GenreService(AppDbcontext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async ValueTask<bool> CreateGenre(Genre genre)
        {
            await _dbContext.Genres.AddAsync(genre);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }


        public async ValueTask<List<Genre>> GetAllGenre()
        {
            return await _dbContext.Genres.Include(g => g.Books).ToListAsync();
        }

        public async ValueTask<Genre> GetByNameGenre(string name)
        {
            return await _dbContext.Genres
                                   .Include(g => g.Books)
                                   .FirstOrDefaultAsync(x => x.Name == name);
        }


    }
}
