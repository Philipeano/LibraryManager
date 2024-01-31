using LibraryManager.Data.Entities;
using LibraryManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Web.Pages.Books
{
    public class AddBookModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public AddBookModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Book NewBook { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NewBook.Id = Guid.NewGuid();
                NewBook.Created = DateTime.Now;
                NewBook.Updated = DateTime.Now;
                _bookRepository.CreateBook(NewBook);
                return Redirect("/books/view-all");
            }

            return Page();
        }
    }
}
