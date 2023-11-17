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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int initialNumber;
        private int secondNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            initialNumber = new Random().Next(1, 21);
            secondNumber = new Random().Next(1, 21);

            txtFirstNumber.Text = $"{initialNumber}";
            txtSecondNumber.Text = "";
            txtResult.Text = "";
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            txtSecondNumber.Text = $"{secondNumber}";

            bool? isBiggerSelected = rbBigger.IsChecked;
            bool win = isBiggerSelected switch
            {
                true when secondNumber >= initialNumber => true,
                false when secondNumber <= initialNumber => true,
                _ => false  // when both radio buttons are left unchecked
            };

            txtResult.Text = win ? "You win!" : "You lose";
        }
    }
}
