using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5Part1.Data;
using Lab5Part1.Models;

namespace Lab5Part1.Pages.FluentUsers
{
    public class EditModel : PageModel
    {
        private readonly Lab5Part1.Data.Lab5Part1FluentUserContext _context;

        public EditModel(Lab5Part1.Data.Lab5Part1FluentUserContext context)
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

            var fluentuser =  await _context.FluentUsers.FirstOrDefaultAsync(m => m.UserId == id);
            if (fluentuser == null)
            {
                return NotFound();
            }
            FluentUser = fluentuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FluentUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FluentUserExists(FluentUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FluentUserExists(Guid id)
        {
            return _context.FluentUsers.Any(e => e.UserId == id);
        }
    }
}
