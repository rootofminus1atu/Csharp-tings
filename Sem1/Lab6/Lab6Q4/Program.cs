namespace Lab6Q4
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            //a reactor, if the temp raises above 250 it shuts down

            Random rnd = new();

            int temp;
            int temp2 = 0;

            //modifiable variables
            int tempStep = 10; //by how much the temperature can jump from one instant to another


            for (int i = 0; i < 1000000; i++)
            {
                temp = rnd.Next(temp2 - tempStep, temp2 + tempStep + 2);
                temp2 = temp;
                Console.WriteLine(temp);

                if (temp > 250)
                {
                    Console.WriteLine("Temperature exceeded 250C, shutting down NOW");
                    break;
                }

                Thread.Sleep(10);
            }


        }
    }
}