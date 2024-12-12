using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;
using Example19_11_24.Pages.Students;

namespace Example19_11_24.Pages.Students
{
    public class StudentsWithCoursesModel : PageModel
    {
        private readonly Example19_11_24.Data.CollegeContext _context;

        public StudentsWithCoursesModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Courses)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostUnenroll(int courseId, int studentId)
        {
            var student = _context.Students.Include(s => s.Courses).FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
                return NotFound();
            Console.WriteLine(student.FirstName);

            var course = _context.Courses.Include(c => c.Students).FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
                return NotFound();
            Console.WriteLine(course.Name);

            student.Courses.Remove(course);
            course.Students.Remove(student);

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}