using LibraryManager.Data.Entities;
using LibraryManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Web.Pages.Books
{
    public class EditBookModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public EditBookModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Book BookToUpdate { get; set; }


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

            BookToUpdate = book;
            return Page();
        }


        public IActionResult OnPost(Guid id)
        {
            if (ModelState.IsValid)
            {
                BookToUpdate.Updated = DateTime.Now;
                _bookRepository.UpdateBook(BookToUpdate);
                return Redirect("/books/view-all");
            }

            return Page();
        }
    }


}
