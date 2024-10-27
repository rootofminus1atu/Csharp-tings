using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RADLab3Solution.Data;
using RADLab3Solution.Models;

namespace RADLab3Solution.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly RADLab3Solution.Data.RADLab3SolutionContextSQLite _context;

        public CreateModel(RADLab3Solution.Data.RADLab3SolutionContextSQLite context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
