using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Practice_CA4_2018_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student("john", 1000),
                new NonEU("john", 1000, "chilean"),
                new Student("john", 1000),
                new NonEU("john", 1000, "indonesian")
            };

            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public int StudentNum { get; set; }
        public string Gender { get; set; }
        public double Fee { get; set; }

        private static int counter = 1;

        public Student() 
        {
            StudentNum = GenerateStudentNum();
        }

        public Student(string gender, double fee)
        {
            StudentNum = GenerateStudentNum();
            Gender = gender;
            Fee = fee;
        }

        private static int GenerateStudentNum()
        {
            return counter++;
        }

        public virtual double CalcDiscount()
        {
            return 0.1 * Fee;
        }

        public override string ToString()
        {
            return $"Student number: {StudentNum}, Gender: {Gender}, Fee: {Fee}, Discount: {CalcDiscount()}";
        }
    }

    public class NonEU : Student
    {
        public string Nationality { get; set; }

        public NonEU(string gender, int fee, string nationality) : base(gender, fee)
        { 
            Nationality = nationality;
        }

        public override double CalcDiscount()
        {
            return 0.02 * Fee;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Nationality: {Nationality}";
        }
    }
}