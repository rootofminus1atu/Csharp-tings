﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext _context;

        public DetailsModel(Rad301_2024_Lab3_books.Data.Rad301_2024_Lab3_booksContext context)
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

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
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
