namespace Lab5Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // displaying and calculating info about a team's performance

            string teamName = "Sligo Humans";
            int wins = 2;
            int losses = 5;
            int draws = 4;
            const int k = -15; //table width


            int total = wins + losses + draws;  
            int points = 3 * wins + 1 * draws;  
            int pointsAlt = 3 * total;          
            double percenter = Convert.ToDouble(points)/Convert.ToDouble(pointsAlt);


            Console.WriteLine($"{"Team",k}{"Played",k}{"Wins",k}{"Losses",k}{"Draws",k}{"Points",k}{"Percentage",k}");
            Console.WriteLine($"{teamName,k}{total,k}{wins,k}{losses,k}{draws,k}{points,k}{percenter,k:p2}");
        }
    }
}