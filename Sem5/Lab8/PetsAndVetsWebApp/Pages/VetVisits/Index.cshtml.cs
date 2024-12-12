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
    public class IndexModel : PageModel
    {
        private readonly PetsAndVetsLibrary.PetsAndVetsContext _context;

        public IndexModel(PetsAndVetsLibrary.PetsAndVetsContext context)
        {
            _context = context;
        }

        public IList<VetVisit> VetVisit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VetVisit = await _context.VetVisits
                .Include(v => v.Pet)
                .Include(v => v.Vet).ToListAsync();
        }
    }
}
