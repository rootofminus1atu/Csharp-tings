using Microsoft.VisualBasic;

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

            Lecturer l1 = new("J", "Joe", "joe@biden");


            ScheduledLesson s1 = new(m1, c1, new DateTime(2022, 1, 3, 9, 0, 0), new DateTime(2022, 1, 3, 10, 0, 0), l1, r1);
            ScheduledLesson s2 = new(m1, c1, new DateTime(2022, 1, 3, 12, 0, 0), new DateTime(2022, 1, 3, 13, 0, 0), l1, r1);
            ScheduledLesson s3 = new(m2, c1, new DateTime(2022, 1, 3, 14, 0, 0), new DateTime(2022, 1, 3, 16, 0, 0), l1, r1);

            CourseTimetable ct = new(new List<ScheduledLesson>() { s1, s2, s3 }, new DateTime(2022, 1, 3), c1.CourseCode);

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

    }

    public class Lecturer : User
    {
        public string LecturerId { get; set; }

        public Lecturer(string lecturerId, string name, string email) : base(name, email)
        {
            LecturerId = lecturerId;
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
    }


    public class ScheduledLesson
    {
        public Module Module { get; set; }
        public Course Course { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Lecturer InClassLecturer { get; set; }
        public Room Room { get; set; }


        public ScheduledLesson(Module module, Course course, DateTime timeStart, DateTime timeEnd, Lecturer inClassLecturer, Room room)
        {
            Module = module;
            Course = course;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            InClassLecturer = inClassLecturer;
            Room = room;
        }

    }

    public abstract class Timetable
    {
        public List<ScheduledLesson> ScheduledLessons { get; set; }
        public DateTime WeekMonday { get; set; }  // probably change this
        public DateTime WeekFriday => WeekMonday.AddDays(5);  // and this


        public Timetable(List<ScheduledLesson> lessons, DateTime weekMonday)
        {
            ScheduledLessons = lessons;
            WeekMonday = weekMonday;
        }
    }

    public class CourseTimetable : Timetable
    {
        public string CourseCode { get; set; }

        public CourseTimetable(List<ScheduledLesson> lessons, DateTime weekMonday, string courseCode) : base(lessons, weekMonday)
        {
            CourseCode = courseCode;
        }

        public void DisplayTimetable()
        {
            Console.WriteLine($"Course timetable for {WeekMonday}");
        }
    }

    public class RoomTimetable : Timetable
    {
        public string RoomId { get; set; }

        public RoomTimetable(List<ScheduledLesson> lessons, DateTime weekMonday, string roomId) : base(lessons, weekMonday)
        {
            RoomId = roomId;
        }
    }
}