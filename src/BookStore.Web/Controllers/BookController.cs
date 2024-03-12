using BookStore.Application.Services.AuthorServices;
using BookStore.Application.Services.BookServices;
using BookStore.Application.Services.GenreServices;
using BookStore.Domain.Entities;
using BookStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        // Get: Book
        public async Task<IActionResult> Index()
        {
            var book = await _bookService.GetAllBook();
            return View(book);
        }

        // Get: Book/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetByIdBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);

        }

        // Get: Book/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new BookCreateViewModel()
            {
                Authors = await _authorService.GetAllAuthor(),
                Genres = await _genreService.GetAllGenre(),
            };

            return View(viewModel);
        }


        // Post: Book/Create
        [HttpPost]

        public async Task<IActionResult> Create(BookCreateViewModel bookCreateView)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBook(bookCreateView.Book);
                return RedirectToAction(nameof(Index));
            }
            return View(bookCreateView);
        }

        // Get: Book/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _bookService.GetByIdBook(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Post: Book/Edit

        [HttpPost]


        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,AuthorId,GenreId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bookService.UpdateBook(id, book);



                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        //   Get:  Book/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _bookService.GetByIdBook(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Post: Book/Delete
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string text)
        {
            var books = await _bookService.GetByNameBook(text);

            return View(nameof(Index),books);
        }
    }
}
