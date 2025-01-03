﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetsAndVetsLibrary;

namespace PetsAndVetsWebApp.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly PetsAndVetsLibrary.PetsAndVetsContext _context;

        public IndexModel(PetsAndVetsLibrary.PetsAndVetsContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Owner = await _context.Owners.ToListAsync();
        }
    }
}