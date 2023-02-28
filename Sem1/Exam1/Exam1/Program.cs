namespace Exam1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // testing

            StudentVotes joe = new StudentVotes("Joe", 46);
            StudentVotes biden = new StudentVotes("Biden", 22);
            StudentVotes donald = new StudentVotes("Donald", 31);

            StudentVotes[] them = new StudentVotes[] { joe, biden, donald };



            StudentVotes bestOne = StudentVotes.FindBestStudent(them);

            Console.WriteLine($"{bestOne.name} won with {bestOne.votes} votes");

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
        }



        static double FindMax(double[] arr)
        {
            double max = arr[0];

            foreach (double num in arr)
                if (num > max)
                    max = num;

            return max;
        }

        static double FindMaxIndex(double[] arr)
        {
            double max = arr[0];
            int maxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                    maxIndex = i;

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
    }
}