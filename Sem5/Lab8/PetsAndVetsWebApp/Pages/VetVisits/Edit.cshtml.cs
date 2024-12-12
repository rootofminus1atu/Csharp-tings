using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetsAndVetsLibrary;

namespace PetsAndVetsWebApp.Pages.VetVisits
{
    public class EditModel : PageModel
    {
        private readonly PetsAndVetsLibrary.PetsAndVetsContext _context;

        public EditModel(PetsAndVetsLibrary.PetsAndVetsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VetVisit VetVisit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetvisit =  await _context.VetVisits.FirstOrDefaultAsync(m => m.Id == id);
            if (vetvisit == null)
            {
                return NotFound();
            }
            VetVisit = vetvisit;
           ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name");
           ViewData["VetId"] = new SelectList(_context.Vets, "Id", "Name");
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

            _context.Attach(VetVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetVisitExists(VetVisit.Id))
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

        private bool VetVisitExists(int id)
        {
            return _context.VetVisits.Any(e => e.Id == id);
        }
    }
}
