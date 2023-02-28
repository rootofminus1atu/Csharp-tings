namespace Lab7Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //app for calculating the amount of CAO points you have
            //I'll optimize the code in the future
            //dictionaries would be useful

            string subject;
            string grade;
            string tempString1 = "";
            string tempString2 = "";

            int i = 1;
            int bonus = 0;
            int total = 0;
            int points = 0;
            double average;

            bool validity;
            bool gotBonus = false;


            while (true)
            {
                validity = true;

                //input your data
                Console.Write($"Enter subject {i}: ");
                subject = Console.ReadLine();

                if (subject.ToLower() == "exit")
                    break;

                Console.Write($"Enter grade {i}: ");
                grade = Console.ReadLine();

                if (grade.ToLower() == "exit")
                    break;



                //check if you might get a bonus
                if (subject.ToLower() == "maths" || subject.ToLower() == "math")
                {
                    bonus = 25;
                    gotBonus = true;
                }
                else
                    bonus = 0;


                //check how many poins you get
                if (grade.ToUpper() == "H1")
                {
                    points = 100 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H2")
                {
                    points = 88 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H3")
                {
                    points = 77 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H4")
                {
                    points = 66 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H5")
                {
                    points = 55 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H6")
                {
                    points = 46 + bonus;
                    total += points;
                }

                else if (grade.ToUpper() == "H7")
                {
                    points = 37;
                    total += points;
                }

                else if (grade.ToUpper() == "H8")
                {
                    points = 0;
                    total += points;
                }

                else
                {
                    Console.WriteLine($"\nInvalid grade\n");
                    validity = false;
                }


                //this "if" is needed here, in case of an invalid grade 
                if (validity == true)
                {
                    Console.WriteLine($"\nYou received {points} points for {subject}\n");
                    i++;
                }
            }


            //final checks
            if (gotBonus == true)
            {
                tempString1 = "*";
                tempString2 = "* includes 25 bonus points";
            }

            if (i == 1)
                i=2;

            average = total / (i - 1);

            //your points!
            Console.WriteLine($"\n\nTotal points: {total,20}{tempString1}");
            Console.WriteLine($"Average points per subject: {average,6}\n\n{tempString2}\n\n");

        }
    }
}