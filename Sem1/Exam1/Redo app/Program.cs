namespace Redo_app
{
    internal class Program
    {
        const int k1 = -32; // all the indents
        const int k2 = -6;
        const int k3 = -16;
        const int k4 = -36;

        static void Main(string[] args)
        {
            // oop solution
            // overcomplicated but it was fun

            Console.Write("Enter number of students : ");
            int num = int.Parse(Console.ReadLine());

            if (num > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] maximum number of 10 students exceeded");  // fancy colors
                Console.ForegroundColor = ConsoleColor.Gray;
                Environment.Exit(0);
            }

            StudentVotes[] studentVotes = new StudentVotes[num];
            string name;
            int vote;



            // input precise info

            for (int i = 0; i < num; i++)
            {
                Console.Write($"\n{"Enter name of student",k1}{i + 1,k2}: ");
                name = Console.ReadLine();

                Console.Write($"{"Enter votes for student",k1}{i + 1,k2}: ");
                vote = int.Parse(Console.ReadLine());

                studentVotes[i] = new StudentVotes(name, vote);
            }



            // all the display info

            string star;
            StudentVotes bestOne = StudentVotes.FindBestStudent(studentVotes);

            Console.WriteLine($"\n\n{"Student",k3} Votes");
            foreach (StudentVotes student in studentVotes)
            {
                if (student.name == bestOne.name)
                    star = "*";
                else
                    star = "";

                Console.WriteLine($"{student.name,k3} {student.votes} {star}");
            }

            Console.WriteLine($"\n{"Total votes",k4} {StudentVotes.VotesSum(studentVotes)}");
            Console.WriteLine($"{"Average",k4} {StudentVotes.VotesAverage(studentVotes):.##}");
            Console.WriteLine($"{"Highest number of votes",k4} {bestOne.votes}");
            Console.WriteLine($"{"Student with highest votes",k4} {bestOne.name}");

        }

        static int FindMaxIndex(double[] arr)
        {
            double max = arr[0];
            int maxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }

            return maxIndex;
        }

        static double ArraySum(double[] arr)
        {
            double sum = 0;

            foreach (double num in arr)
                sum += num;

            return sum;
        }

        static double ArrayAverage(double[] arr)
        {
            return ArraySum(arr) / arr.Length;
        }





        static void WriteLineColor(string text) // wip should improve to add a color parameter
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] maximum number of 10 students exceeded");  // fancy colors
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        




    }

    public class StudentVotes
    {
        public string name;
        public double votes;

        public StudentVotes(string nameInput, double votesInput)
        {
            this.name = nameInput;
            this.votes = votesInput;
        }


        public static StudentVotes FindBestStudent(StudentVotes[] arr)
        {
            // the one who has the most amount of votes

            StudentVotes best = arr[0];

            foreach (StudentVotes student in arr)
                if (student.votes > best.votes)
                    best = student;

            return best;
        }

        public static double VotesSum(StudentVotes[] arr)
        {
            double sum = 0;

            foreach (StudentVotes student in arr)
                sum += student.votes;

            return sum;
        }

        public static double VotesAverage(StudentVotes[] arr)
        {
            return VotesSum(arr) / arr.Length;
        }
    }
}