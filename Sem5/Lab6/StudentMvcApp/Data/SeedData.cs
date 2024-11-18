using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;

namespace StudentMvcApp.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentContext(
                serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>()))
            {
                if (context == null || context.Courses == null)
                {
                    throw new ArgumentNullException("Null Context");
                }

                if (!context.Courses.Any())
                {
                    Console.WriteLine("no courses, creating seed data");

                    context.Database.EnsureCreated();

                    var course = new Course
                    {
                        Name = "Compsci",
                        Department = "Wizardry",
                        Lecturer = "Dr. Joe"
                    };
                    context.Courses.Add(course);
                    context.SaveChanges();

                    Console.WriteLine("course created");

                    var student1 = new Student
                    {
                        Name = "John Doe",
                        Age = 20,
                        Email = "john.doe@example.com",
                        CourseId = course.Id,
                        Address = "nowhere"
                    };

                    var student2 = new Student
                    {
                        Name = "Jane Doe",
                        Age = 22,
                        Email = "jane.doe@example.com",
                        CourseId = course.Id,
                        Address = "somewhere"
                    };

                    context.Students.AddRange(student1, student2);
                    context.SaveChanges();
                }
            }
        }
    }
}
