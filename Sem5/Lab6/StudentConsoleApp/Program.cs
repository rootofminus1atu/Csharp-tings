using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StudentClassLibrary;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using StudentConsoleApp;

void InsertSomeData()
{

    using (var context = new StudentContext())
    {
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

// InsertSomeData();

using (var context = new StudentContext())
{
    var students = context.Students.Include(s => s.Course).ToList();
    foreach (var s in students)
    {
        Console.WriteLine($"student: {s.Name}");
    }
}

Console.WriteLine("Hello, World!");