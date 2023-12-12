using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Collection of teams containing players.
        /// </summary>
        private List<Team> teams = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes and populates data for teams and players representing different countries.
        /// </summary>
        private void GetData()
        {
            // French players
            Player p1 = new("Marie", "WWDDL");
            Player p2 = new("Claude", "DDDLW");
            Player p3 = new("Antoine", "LWDLW");

            // Italian players
            Player p4 = new("Marco", "WWDLL");
            Player p5 = new("Giovanni", "LLLLD");
            Player p6 = new("Valentina", "DLWWW");

            // Spanish players
            Player p7 = new("Maria", "WWWWW");
            Player p8 = new("Jose", "LLLLL");
            Player p9 = new("Pablo", "DDDDD");

            Team t1 = new("France", new() { p1, p2, p3 });
            Team t2 = new("Italy", new() { p4, p5, p6 });
            Team t3 = new("Spain", new() { p7, p8, p9 });

            teams = new List<Team>() { t1, t2, t3 };
            teams.Sort();
            teams.Reverse();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
            lbxTeams.ItemsSource = teams;
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team? chosenTeam = lbxTeams.SelectedItem as Team;

            lbxPlayers.ItemsSource = chosenTeam?.Players;
        }


        /// <summary>
        /// Adds a new match result to the player's result record and refreshes the UI to reflect those changes.
        /// </summary>
        /// <param name="c">The character representing a match outcome (W, D, or L).</param>
        private void AddResult(char c)
        {
            Player? chosenPlayer = lbxPlayers.SelectedItem as Player;

            chosenPlayer?.AddResult(c);

            teams.Sort();
            teams.Reverse();
            lbxPlayers.Items.Refresh();
            lbxTeams.Items.Refresh();
            ManageStars(chosenPlayer);
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            AddResult('W');
        }

        private void btnLoss_Click(object sender, RoutedEventArgs e)
        {
            AddResult('L');
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            AddResult('D');
        }

        private void lbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player? chosenPlayer = lbxPlayers.SelectedItem as Player;

            ManageStars(chosenPlayer);
        }

        /// <summary>
        /// Updates the star images based on the star rating of the chosen player.
        /// </summary>
        /// <param name="chosenPlayer">The player for whom the star rating is to be displayed.</param>
        private void ManageStars(Player? chosenPlayer)
        {
            int? howManyStars = chosenPlayer?.CalculateStars();
            const string STAR_SOLID_PATH = "/images/starsolid.png";
            const string STAR_OUTLINE_PATH = "/images/staroutline.png";

            star1.Source = new BitmapImage(new Uri(howManyStars >= 1 ? STAR_SOLID_PATH : STAR_OUTLINE_PATH, UriKind.Relative));
            star2.Source = new BitmapImage(new Uri(howManyStars >= 2 ? STAR_SOLID_PATH : STAR_OUTLINE_PATH, UriKind.Relative));
            star3.Source = new BitmapImage(new Uri(howManyStars == 3 ? STAR_SOLID_PATH : STAR_OUTLINE_PATH, UriKind.Relative));
        }
    }
}
