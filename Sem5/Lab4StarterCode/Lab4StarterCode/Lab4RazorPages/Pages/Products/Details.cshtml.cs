using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4RazorPages.Data;
using Lab4RazorPages.Models;

namespace Lab4RazorPages.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Lab4RazorPages.Data.Lab4RazorPagesContext _context;

        public DetailsModel(Lab4RazorPages.Data.Lab4RazorPagesContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
