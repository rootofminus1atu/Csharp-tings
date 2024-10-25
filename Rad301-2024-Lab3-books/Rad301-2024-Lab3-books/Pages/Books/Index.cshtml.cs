using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rad301_2024_Lab3_books.Data;
using Rad301_2024_Lab3_books.Models;

namespace Rad301_2024_Lab3_books.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext _context;

        public IndexModel(Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
