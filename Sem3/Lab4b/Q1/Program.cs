using System.Text;

namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new("Sligo Rovers");
            Team t2 = new("Finn Harps");
            Team t3 = new("Galway United");

            List<Team> teams = new() { t1, t2, t3 };

            DisplayTeams(teams);

            teams[0].AddResult(Result.Win);
            teams[2].AddResult(Result.Win);
            teams[0].AddResult(Result.Draw);
            teams[0].AddResult(Result.Lose);
            teams[1].AddResult(Result.Draw);
            teams[1].AddResult(Result.Lose);

            DisplayTeams(teams);



            t1.Players.Add(new Player("Ed McGinty", "Goalkeeper"));
            t1.Players.Add(new Player("John Mahon", "Defender"));
            t1.Players.Add(new Player("Ronan Coughlan", "Forward"));

            Console.WriteLine(t1.GetTeamSheet());
        }

        static void DisplayTeams(List<Team> teams)
        {
            Console.WriteLine(Team.GetHeader());

            List<Team> sortedTeams = new(teams);
            sortedTeams.Sort();
            sortedTeams.Reverse();

            foreach (Team team in sortedTeams)
            {
                Console.WriteLine(team.DisplayTeamTable());
            }
        }
    }

    

    

}