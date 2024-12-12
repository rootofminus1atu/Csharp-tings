using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetsAndVetsLibrary;

namespace PetsAndVetsWebApp.Pages.VetVisits
{
    public class DeleteModel : PageModel
    {
        private readonly PetsAndVetsLibrary.PetsAndVetsContext _context;

        public DeleteModel(PetsAndVetsLibrary.PetsAndVetsContext context)
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

            var vetvisit = await _context.VetVisits.FirstOrDefaultAsync(m => m.Id == id);

            if (vetvisit == null)
            {
                return NotFound();
            }
            else
            {
                VetVisit = vetvisit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetvisit = await _context.VetVisits.FindAsync(id);
            if (vetvisit != null)
            {
                VetVisit = vetvisit;
                _context.VetVisits.Remove(VetVisit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
