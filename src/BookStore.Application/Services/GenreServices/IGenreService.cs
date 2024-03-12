using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.GenreServices
{
    public interface IGenreService
    {
        public ValueTask<bool> CreateGenre(Genre genre);
        public ValueTask<Genre> GetByNameGenre(string name);
        public ValueTask<Genre> GetByIdGenre(int id);
        public ValueTask<List<Genre>> GetAllGenre();
    
    }
}
