namespace Lab6Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //spike generator
            // damn coming back to this after half a year
            // the way I named things wasn't all that good

            string myStr;
            int i, j;
            double k;

            //modifiable variables
            string message = "hi";
            int length = 30;
            int amplitude = 20;
            int howMany = 4;
            int totalLength = length * howMany;


            for (i = 0; i < totalLength; i++)
            {
                myStr = "";
                k = amplitude * (Math.Acos(Math.Cos((2 * 3.14 / length) * i))); //ugly math

                for (j = 0; j <= k; j++)
                {
                    myStr += " ";
                }


                myStr += message;

                Console.WriteLine(myStr);
            }
        }
    }
}