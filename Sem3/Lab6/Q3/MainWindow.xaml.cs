using System;
using System.Collections.Generic;
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

namespace Q3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> eightBallResponses = new List<string>
        {
            "Outlook not so good.",
            "Yes, definitely.",
            "Reply hazy, try again.",
            "Cannot predict now.",
            "As I see it, yes.",
            "Don't count on it.",
            "Most likely.",
            "Ask again later.",
            "My sources say no.",
            "Without a doubt.",
            "Concentrate and ask again.",
            "Very doubtful.",
            "It is certain.",
            "Outlook good.",
            "Better not tell you now.",
            "Yes, but proceed with caution.",
            "My reply is no.",
            "Signs point to yes.",
            "Maybe.",
            "Certainly not."
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAsk_Click(object sender, RoutedEventArgs e)
        {
            string question = txtQuestion.Text;

            Random rng = new Random();
            string randomResponse = eightBallResponses.OrderBy(item => rng.Next()).First();

            txtAnswer.Text = randomResponse;
        }
    }
}
