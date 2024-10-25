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
    public class DeleteModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3Context _context;

        public DeleteModel(Lab4Part3.Data.Lab4Part3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SupplierID == id);

            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier != null)
            {
                Supplier = supplier;
                _context.Supplier.Remove(Supplier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
