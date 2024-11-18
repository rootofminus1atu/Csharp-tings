using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using StudentMvcApp.Data;

namespace StudentMvcApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly StudentMvcApp.Data.StudentContext _context;

        public IndexModel(StudentMvcApp.Data.StudentContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
