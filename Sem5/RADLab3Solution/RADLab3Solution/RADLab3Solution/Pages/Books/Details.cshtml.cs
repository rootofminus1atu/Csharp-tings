using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RADLab3Solution.Data;
using RADLab3Solution.Models;

namespace RADLab3Solution.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly RADLab3Solution.Data.RADLab3SolutionContextSQLite _context;

        public DetailsModel(RADLab3Solution.Data.RADLab3SolutionContextSQLite context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
