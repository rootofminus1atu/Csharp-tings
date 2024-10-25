using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5Part1.Data;
using Lab5Part1.Models;

namespace Lab5Part1.Pages.FluentUsers
{
    public class CreateModel : PageModel
    {
        private readonly Lab5Part1.Data.Lab5Part1FluentUserContext _context;

        public CreateModel(Lab5Part1.Data.Lab5Part1FluentUserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FluentUsers.Add(FluentUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
