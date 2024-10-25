using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab4Part3.Data;
using Lab4Part3.Models;

namespace Lab4Part3.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3Context _context;

        public CreateModel(Lab4Part3.Data.Lab4Part3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
