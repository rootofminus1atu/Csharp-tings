using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Module m1 = new("M123", "Math");
            Module m2 = new("W542", "Web design");

            Course c1 = new("SD3747", "Software dev");

            Room r1 = new("B1232", RoomCategory.Lab);
            Room r2 = new("D1000", RoomCategory.Lecturehall);

            Lecturer l1 = new("J1B", "Joe Biden", "joe@biden");

            // you can create as many lessons as you want here
            ScheduledLesson s1 = new(m1, c1, new DateTime(2022, 1, 3, 9, 0, 0), new DateTime(2022, 1, 3, 10, 0, 0), l1, r1);
            ScheduledLesson s2 = new(m1, c1, new DateTime(2022, 1, 3, 12, 0, 0), new DateTime(2022, 1, 3, 13, 0, 0), l1, r2);
            ScheduledLesson s3 = new(m2, c1, new DateTime(2022, 1, 4, 14, 0, 0), new DateTime(2022, 1, 4, 16, 0, 0), l1, r1);
            // as long as they're in the schedule's timeframe (from 3rd Jan to 8th) they should be displayed in it
            
            // don't forget to include them in the list down below
            List<ScheduledLesson> lessons = new() { s1, s2, s3 };
            CourseTimetable ct = new(lessons, new DateTime(2022, 1, 3), c1.CourseCode);

            ct.DisplayTimetable();


        }
    }

    public class Module
    {
        public string ModuleId { get; set; }
        public string Name { get; set; }


        public Module(string moduleId, string name)
        {
            ModuleId = moduleId;
            Name = name;
        }

        public override string ToString()
        {
            return $"ModuleId: {ModuleId}, Name: {Name} ";
        }
    }

    public class Course
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }

        public Course(string courseCode, string name)
        {
            CourseCode = courseCode;
            Name = name;
        }

        public override string ToString()
        {
            return $"CourseCode: {CourseCode}, Name: {Name}";
        }
    }

    public class  User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}";
        }

    }

    public class Lecturer : User
    {
        public string LecturerId { get; set; }

        public Lecturer(string lecturerId, string name, string email) : base(name, email)
        {
            LecturerId = lecturerId;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, LecturerId: {LecturerId}";
        }
    }

    public enum RoomCategory
    {
        Lab,
        Lecturehall
    }

    public class Room
    {
        public string RoomId { get; set; }
        public RoomCategory Category { get; set; }


        public Room(string roomId, RoomCategory category)
        {
            RoomId = roomId;
            Category = category;
        }

        public override string ToString()
        {
            return $"RoomId: {RoomId}, RoomCategory: {Category}";
        }
    }


    public class ScheduledLesson : IComparable<ScheduledLesson>
    {
        public Module Module { get; set; }
        public Course Course { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Lecturer InClassLecturer { get; set; }
        public Room Room { get; set; }

        public DayOfWeek DayOfWeek => TimeStart.DayOfWeek;


        public ScheduledLesson(Module module, Course course, DateTime timeStart, DateTime timeEnd, Lecturer inClassLecturer, Room room)
        {
            Module = module;
            Course = course;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            InClassLecturer = inClassLecturer;
            Room = room;
        }

        public override string ToString()
        {
            return $"Module: {Module}, Course: {Course}, TimeStart: {TimeStart}, TimeEnd: {TimeEnd}, InClassLecturer: {InClassLecturer}, Room: {Room}";
        }

        public int CompareTo(ScheduledLesson? other)
        {
            return TimeStart.CompareTo(other?.TimeStart);
        }
    }

    public abstract class Timetable
    {
        public List<ScheduledLesson> ScheduledLessons { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd => WeekStart.AddDays(5);


        public Timetable(List<ScheduledLesson> lessons, DateTime weekStart)
        {
            ScheduledLessons = lessons;
            WeekStart = weekStart;
        }

        public override string ToString()
        {
            return $"ScheduledLessons: {ScheduledLessons.Stringify()}";
        }

        public List<List<ScheduledLesson>> DivideIntoWeekDays()
        {
            return ScheduledLessons
                .GroupBy(l => l.TimeStart.Day)
                .Select(g => g.ToList())
                .Select(g => { g.Sort(); return g; })
                .ToList();
        }
    }

    public class CourseTimetable : Timetable
    {
        public string CourseCode { get; set; }

        public CourseTimetable(List<ScheduledLesson> lessons, DateTime weekStart, string courseCode) : base(lessons, weekStart)
        {
            CourseCode = courseCode;
        }

        public void DisplayTimetable()
        {
            Console.WriteLine($"Course timetable for {WeekStart.ToShortDateString()} - {WeekEnd.ToShortDateString()}");

            var weekDividedLessons = DivideIntoWeekDays();

            foreach (var dayLessons in weekDividedLessons)
            {
                Console.WriteLine($"=== {dayLessons[0].DayOfWeek} ===");
                foreach (var lesson in dayLessons)
                {
                    Console.WriteLine($"{lesson.TimeStart.TimeOfDay} - {lesson.TimeEnd.TimeOfDay}   {lesson.Module.Name} in {lesson.Room.RoomId} with {lesson.InClassLecturer.Name}");
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, CourseCode: {CourseCode}";
        }
    }

    public class RoomTimetable : Timetable
    {
        public string RoomId { get; set; }

        public RoomTimetable(List<ScheduledLesson> lessons, DateTime weekStart, string roomId) : base(lessons, weekStart)
        {
            RoomId = roomId;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, RoomId: {RoomId}";
        }
    }



    public static class EnumerableExtension
    {
        /// <summary>
        /// Returns a dev-friendly string representation of an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="list">The enumerable to stringify.</param>
        /// <returns>A string representation of the enumerable.</returns>
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }

        /// <summary>
        /// Returns a dev-friendly string representation of an <see cref="IEnumerable{T}"/> with a given delimeter string.
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="list">The enumerable to stringify.</param>
        /// <param name="delimeter">The delimter.</param>
        /// <returns>A string representation of the enumerable.</returns>
        public static string Stringify<T>(this IEnumerable<T> list, string delimeter)
        {
            return $"[ {string.Join(delimeter, list)} ]";
        }
    }
}