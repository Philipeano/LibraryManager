using LibraryManager.Data.Entities;
using LibraryManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Web.Pages.Books
{
    public class ViewAllBooksModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public ViewAllBooksModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> Books { get; set; }


        public void OnGet()
        {
            // Retrieve all the books from the DB
            Books = _bookRepository.GetAllBooks();
        }

        public IActionResult OnGetDelete(Guid? id)
        {
            // If the id is missing or empty, treat this as a bad request
            if (id == null || id.Value == Guid.Empty)
            {
                return BadRequest();
            }

            // Try deleting the book via the repository service
            _bookRepository.DeleteBook(id.Value);

            // Reload the books from DB after delete
            Books = _bookRepository.GetAllBooks();
            return Page();
        }

    }
}
