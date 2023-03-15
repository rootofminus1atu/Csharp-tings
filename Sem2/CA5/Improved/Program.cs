using System.Text.RegularExpressions;

namespace Improved
{
    internal class Program
    {
        public static Dictionary<double, char> markToGrade = new Dictionary<double, char>
        {
            // upper bound for each grade
            [40] = 'F',
            [50] = 'E',
            [60] = 'D',
            [70] = 'C',
            [80] = 'B',
            [100] = 'A',
        };

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() { };



            // main loop

            while (true)
            {
                string num = "";
                while (!IsStudentNum(num))
                {
                    Console.Write($"Input student number: ");
                    num = Console.ReadLine();
                }

                string mark = "";
                while (!IsDoubleTo100(mark))
                {
                    Console.Write($"Input student mark: ");
                    mark = Console.ReadLine();
                }

                char grade = DetermineGradeV3(double.Parse(mark));


                Student currentStudent = new Student(num, double.Parse(mark), grade);
                students.Add(currentStudent);


                Console.WriteLine($"\nCongratulations {currentStudent.number}! Your grade is: {currentStudent.grade}\n");


                Console.Write($"Exit? (y/n)");
                string exit = Console.ReadLine();

                if (exit == "y")
                    break;
            }



            // ugly display below

            Console.WriteLine(StringMult("=", 30));

            foreach (char grade in markToGrade.Values)
                Console.WriteLine($"Total {grade} grades: {students.CountGrades(grade)}");

            Console.WriteLine(StringMult("=", 30));

            foreach (char grade in markToGrade.Values)
                Console.WriteLine($"Average mark for {grade}: {students.AverageMark(grade)}");

            Console.WriteLine(StringMult("=", 30));

            Console.WriteLine($"Total number of students: {students.Count}");
            Console.WriteLine($"Overall average mark: {students.OverallAverageMark()}\n");

            Console.WriteLine(StringMult("=", 30));
        }

        // calculations
        public static char DetermineGradeV2(double mark)
        {
            char grade = mark switch
            {
                double m when m < 40 => 'F',
                double m when m < 50 => 'E',
                double m when m < 60 => 'D',
                double m when m < 70 => 'C',
                double m when m < 80 => 'B',
                double m when m <= 100 => 'A',
                _ => 'F'  // default case, if an error somehow occurs
            };

            return grade;
        }

        public static char DetermineGradeV3(double mark)
        {
            char grade = 'F';  // default

            foreach (var pair in markToGrade)
            {
                grade = pair.Value;

                if (mark <= pair.Key)
                    break;
            }

            return grade;
        }


        // utility
        public static string StringMult(string str, int num)
        {
            string start = "";

            for (int i = 0; i < num; i++)
                start += str;

            return start;
        }


        // validation
        public static bool IsStudentNum(string input)
        {
            Regex re = new Regex(@"^[sS]\d{8}$");

            if (re.IsMatch(input))
                return true;

            return false;
        }

        public static bool IsDoubleTo100(string input)
        {
            Regex re = new Regex(@"^([0-9]{1,2}){1}(\.[0-9]{1,})?$");
            // probably not the prettiest regext but it works

            if (re.IsMatch(input) == true || input == "100")
                return true;

            return false;
        }
    }

    public class Student
    {
        public string number { get; set; }
        public double mark { get; set; }
        public char grade { get; set; }

        public Student(string number, double mark, char grade)
        {
            this.number = number;
            this.mark = mark;
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"Student number: {this.number}\nMark: {this.mark}\nGrade: {this.grade}";
        }
    }

    public static class StudentExtensions
    {
        public static int CountGrades(this List<Student> students, char target)
        {
            int total = 0;

            foreach (Student student in students)
                if (student.grade == target)
                    total++;

            return total;
        }

        public static double AverageMark(this List<Student> students, char target)
        {
            double total = 0;

            int howMany = students.CountGrades(target);
            if (howMany == 0)
                return 0;

            foreach (Student student in students)
                if (student.grade == target)
                    total += student.mark;

            return total / howMany;
        }

        public static double OverallAverageMark(this List<Student> students)
        {
            double total = 0;

            int howMany = students.Count;
            if (howMany == 0)
                return 0;

            foreach (Student student in students)
                total += student.mark;

            return total / howMany;
        }
    }

}