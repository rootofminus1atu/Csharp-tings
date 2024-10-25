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
    public class IndexModel : PageModel
    {
        private readonly Lab5Part1.Data.Lab5Part1FluentUserContext _context;

        public IndexModel(Lab5Part1.Data.Lab5Part1FluentUserContext context)
        {
            _context = context;
        }

        public IList<FluentUser> FluentUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FluentUser = await _context.FluentUsers.ToListAsync();
        }
    }
}
