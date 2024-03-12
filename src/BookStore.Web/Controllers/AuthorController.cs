using BookStore.Application.Services.AuthorServices;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // Get: Authors
        public async Task<IActionResult> Index()
        {
            var book = await _authorService.GetAllAuthor();
            return View(book);

        }

        // Get: Author/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetByIdAuthor(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);

        }

        // Get: Author/Create
        public IActionResult Create()
        {
            return View();
        }


        // Post: Authors/Create
        [HttpPost]
    
        public async Task<IActionResult> Create([Bind("Id,FullName")] Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.CreateAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // Get: Author/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetByIdAuthor(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Post: Author/Edit

        [HttpPost]
        

        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              await _authorService.UpdateAuthor(id, author);
               


                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //   Get:  Author/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _authorService.GetByIdAuthor(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Post: Author/Delete
        [HttpPost, ActionName("Delete")]
   
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _authorService.DeleteAuthor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
