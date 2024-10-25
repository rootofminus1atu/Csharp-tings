using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Data;
using Lab4Part3.Models;

namespace Lab4Part3.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3Context _context;

        public IndexModel(Lab4Part3.Data.Lab4Part3Context context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _context.Supplier.ToListAsync();
        }
    }
}
