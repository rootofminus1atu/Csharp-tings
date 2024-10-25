using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab4RazorPages.Data;
using Lab4RazorPages.Models;

namespace Lab4RazorPages.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Lab4RazorPages.Data.Lab4RazorPagesContext _context;

        public CreateModel(Lab4RazorPages.Data.Lab4RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
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
