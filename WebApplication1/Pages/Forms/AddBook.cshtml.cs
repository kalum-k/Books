using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Forms
{
    public class AddBookModel : PageModel
    {
        [BindProperty]
        public BookModel Book { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            return RedirectToPage("../Index",

                new { Tittles = Book.Tittles }
                );
        }
    }
}
