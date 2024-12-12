using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsAndVetsLibrary;

namespace PetsAndVetsWebApp.Pages.Vets
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
            return Page();
        }

        [BindProperty]
        public Vet Vet { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vets.Add(Vet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
