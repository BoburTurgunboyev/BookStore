using BookStore.Application.Services.GenreServices;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class GenreController : Controller
    {
 private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // Get: Genre
        public async Task<IActionResult> Index()
        {
            var genre = await _genreService.GetAllGenre();
            return View(genre);

        }

        // Get: Genre/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreService.GetByIdGenre(id.Value);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);

        }

        // Get: Genre/Create
        public IActionResult Create()
        {
            return View();
        }


        // Post: Genre/Create
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreService.CreateGenre(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

   

    }
}
