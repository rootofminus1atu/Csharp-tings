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
    public class IndexModel : PageModel
    {
        private readonly RADLab3Solution.Data.RADLab3SolutionContextSQLite _context;

        public IndexModel(RADLab3Solution.Data.RADLab3SolutionContextSQLite context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.Include(b => b.Publisher).Include(b => b.Author).AsNoTracking().ToListAsync();
        }
    }
}
