namespace Student_class
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int howMany = 3;

            Student[] students = new Student[howMany];

            for (int i = 0; i < howMany; i++)
            {
                Console.Write($"Input student {i + 1}'s number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write($"Input student {i + 1}'s name: ");
                string name = Console.ReadLine();
                Console.Write($"Input student {i + 1}'s mark: ");
                int mark = int.Parse(Console.ReadLine());

                students[i] = new Student(number, name, mark);
            }

            for (int i = 0; i < howMany; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }
    }

    public class Student
    {
        public int number { get; set; }
        public string name { get; set; }
        public int mark { get; set; }

        public Student(int number, string name, int mark)
        {
            this.number = number;
            this.name = name;
            this.mark = mark;
        }

        public override string ToString()
        {
            return $"Student number: {this.number}\nName: {this.name}\nMark: {this.mark}";
        }
    }