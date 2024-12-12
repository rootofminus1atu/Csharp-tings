using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsAndVetsLibrary;

namespace PetsAndVetsWebApp.Pages.VetVisits
{
    public class CreateModel : PageModel
    {
        private readonly PetsAndVetsLibrary.PetsAndVetsContext _context;

        public CreateModel(PetsAndVetsLibrary.PetsAndVetsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name");
        ViewData["VetId"] = new SelectList(_context.Vets, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public VetVisit VetVisit { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VetVisits.Add(VetVisit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
