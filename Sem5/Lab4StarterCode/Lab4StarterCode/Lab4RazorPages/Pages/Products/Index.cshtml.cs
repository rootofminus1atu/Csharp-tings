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
    public class IndexModel : PageModel
    {
        private readonly Lab4RazorPages.Data.Lab4RazorPagesContext _context;

        public IndexModel(Lab4RazorPages.Data.Lab4RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.associatedCategory).ToListAsync();
        }
    }
}
