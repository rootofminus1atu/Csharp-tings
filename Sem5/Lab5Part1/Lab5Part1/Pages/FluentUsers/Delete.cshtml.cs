using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5Part1.Data;
using Lab5Part1.Models;

namespace Lab5Part1.Pages.FluentUsers
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5Part1.Data.Lab5Part1FluentUserContext _context;

        public DeleteModel(Lab5Part1.Data.Lab5Part1FluentUserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.FluentUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (fluentuser == null)
            {
                return NotFound();
            }
            else
            {
                FluentUser = fluentuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.FluentUsers.FindAsync(id);
            if (fluentuser != null)
            {
                FluentUser = fluentuser;
                _context.FluentUsers.Remove(FluentUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
