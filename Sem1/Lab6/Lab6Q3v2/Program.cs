namespace Lab6Q3v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //snake generator

            string myStr;
            double k;

            //modifiable variables
            string message = "hi";
            int length = 100;
            int amplitude = 100;
            int howMany = 2;
            int totalLength = length*howMany;


            for (int i = 0; i < totalLength*1000; i++)
            {
                myStr = "";
                k = amplitude * Math.Pow(Math.Sin((Math.PI/length)*i), 2);

                for(int j = 0; j <= k; j++)
                    myStr += " ";
                
                myStr += message;
                Thread.Sleep(10);

                Console.WriteLine(myStr);
            }
        }
    }
}