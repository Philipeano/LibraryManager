using LibraryManager.Data.Entities;
using LibraryManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Web.Pages.Books
{
    public class ViewBookModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public ViewBookModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Guid Id { get; set; }

        public Book SelectedBook { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            // If the id is missing or empty, treat this as a bad request
            if (id == null || id.Value == Guid.Empty)
            {
                return BadRequest();
            }

            // Try retrieving the book
            var book = _bookRepository.GetBook(id.Value);

            // If the id does not match any book, report as not found
            if (book == null)
            {
                return NotFound();
            }

            SelectedBook = book;
            return Page();
        }
    }
}
