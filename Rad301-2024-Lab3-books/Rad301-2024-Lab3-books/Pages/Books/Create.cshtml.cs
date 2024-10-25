using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rad301_2024_Lab3_books.Data;
using Rad301_2024_Lab3_books.Models;

namespace Rad301_2024_Lab3_books.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext _context;

        public CreateModel(Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
