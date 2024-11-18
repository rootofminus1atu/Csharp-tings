using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using StudentMvcApp.Data;

namespace StudentMvcApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentMvcApp.Data.StudentContext _context;

        public IndexModel(StudentMvcApp.Data.StudentContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Course).ToListAsync();
        }
    }
}
