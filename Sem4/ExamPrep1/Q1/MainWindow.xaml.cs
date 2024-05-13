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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieData db = new MovieData();
        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            using(db)
            {
                lbxMovies.ItemsSource = db.Movies.ToList();
            }
        }

        private void lbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxMovies.SelectedItem is Movie selectedMovie)
            {
                txtDescription.Text = selectedMovie.Description;
            } 
            else
            {
                txtDescription.Text = string.Empty;
            }
        }
    }
}
