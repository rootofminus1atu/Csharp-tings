using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab7Again.Data;
using Lab7Again.Models;

namespace Lab7Again.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly Lab7Again.Data.Lab7AgainContext _context;

        public IndexModel(Lab7Again.Data.Lab7AgainContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact.ToListAsync();
        }
    }
}
