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
    }
}
