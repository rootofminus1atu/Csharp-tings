using System.Text.RegularExpressions;

namespace Validation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> students = new List<string>() { };
            List<double> marks = new List<double>() { };
            List<char> grades = new List<char>() { };


            Console.WriteLine("Started");


            // part 1

            int i = 0;
            while (true)
            {
                string studentNum = "";
                while (!IsStudentNum(studentNum))
                {
                    Console.Write($"Input student {i + 1}'s number: ");
                    studentNum = Console.ReadLine();
                }


                string studentMark = "";
                while (!IsDoubleTo100(studentMark))
                {
                    Console.Write($"Input student {i + 1}'s mark: ");
                    studentMark = Console.ReadLine();
                }

                char studentGrade = DetermineGrade(double.Parse(studentMark));

                students.Add(studentNum);
                marks.Add(double.Parse(studentMark));
                grades.Add(studentGrade);


                // part 2 task 5 (I assume it's supposed to be displayed each and every time)
                Console.WriteLine($"\nCongratulations {studentNum}! Your grade is: {studentGrade}\n");


                Console.Write($"Exit? (y/n)");
                string exit = Console.ReadLine();

                if (exit == "y")
                    break;

                i++;
            }



            // part 2  
            // if I had more time I'd use a for loop for this
            // and a student class to  keep those 3 lists together
            Console.WriteLine("\n===========================");

            Console.WriteLine($"Total F grades: {CountGrades(grades, 'F')}");
            Console.WriteLine($"Total E grades: {CountGrades(grades, 'E')}");
            Console.WriteLine($"Total D grades: {CountGrades(grades, 'D')}");
            Console.WriteLine($"Total C grades: {CountGrades(grades, 'C')}");
            Console.WriteLine($"Total B grades: {CountGrades(grades, 'B')}");
            Console.WriteLine($"Total A grades: {CountGrades(grades, 'A')}");

            Console.WriteLine("===========================");

            Console.WriteLine($"Average mark for F: {AverageMark(grades, marks, 'F')}");
            Console.WriteLine($"Average mark for E: {AverageMark(grades, marks, 'E')}");
            Console.WriteLine($"Average mark for D: {AverageMark(grades, marks, 'D')}");
            Console.WriteLine($"Average mark for C: {AverageMark(grades, marks, 'C')}");
            Console.WriteLine($"Average mark for B: {AverageMark(grades, marks, 'B')}");
            Console.WriteLine($"Average mark for A: {AverageMark(grades, marks, 'A')}");

            Console.WriteLine("===========================");

            Console.WriteLine($"Total number of students: {students.Count}");
            Console.WriteLine($"Overall average mark: {OverallAverageMark(marks)}\n");

        }

        // calculations

        public static int CountGrades(List<char> list, char target)
        {
            int total = 0;

            foreach (char grade in list)
                if (grade == target)
                    total++;

            return total;
        }

        public static double AverageMark(List<char> grades, List<double> marks, char target)
        {
            double total = 0;

            int howMany = CountGrades(grades, target);
            if (howMany == 0)
                return 0;

            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] == target)
                    total += marks[i];
            }

            return total / howMany;
        }

        public static double OverallAverageMark(List<double> marks)
        {
            double total = 0;

            int howMany = marks.Count;
            if (howMany == 0)
                return 0;

            foreach (double mark in marks)
                total += mark;

            return total / howMany;
        }

        public static char DetermineGrade(double mark)
        {
            if (mark < 40)
                return 'F';
            else if (mark >= 40 && mark < 50)
                return 'E';
            else if (mark >= 50 && mark < 60)
                return 'D';
            else if (mark >= 60 && mark < 70)
                return 'C';
            else if (mark >= 70 && mark < 80)
                return 'B';
            else
                return 'A';
        }


        // helper

        public static void PrintList<T>(List<T> list)
        {
            foreach (T thing in list)
                Console.WriteLine(thing);
        }


        // validation

        public static bool IsStudentNum(string input)
        {
            Regex re = new Regex(@"^[sS]\d{8}$");

            if (re.IsMatch(input))
                return true;
            else
                return false;
        }

        public static bool IsDoubleTo100(string input)
        {
            Regex re = new Regex(@"^([0-9]{1,2}){1}(\.[0-9]{1,})?$");
            // probably not the best regext but it works

            if (re.IsMatch(input) == true || input == "100")
                return true;
            else
                return false;
        }
    }
}