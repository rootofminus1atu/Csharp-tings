using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private const int MAX_SEATS = 100;
        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            using (var db = new MovieData())
            {
                lbxMovies.ItemsSource = db.Movies.ToList();
            }
        }

        private void RefreshAvailableSeats(int availableSeats)
        {
            // update the number based on how many bookings there are
            int availableSeatsNum = MAX_SEATS - availableSeats;
            txtAvailableSeats.Text = $"{availableSeatsNum}"; ;
        }

        private int GetAvailableSeats(Movie movie, DateTime date)
        {
            using (var db = new MovieData())
            {
                return db.Bookings
                    .Where(b => b.MovieID == movie.MovieID && b.BookingDate == date)
                    .Select(b => b.NumberOfTickets)
                    .Sum();
            }
        }

        private void lbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxMovies.SelectedItem is Movie selectedMovie)
            {
                txtDescription.Text = selectedMovie.Description;

                // below part just for automatic available seats refreshing (not needed)
                if (dpDate.SelectedDate is DateTime selectedDate)
                {
                    RefreshAvailableSeats(GetAvailableSeats(selectedMovie, selectedDate));
                }
            } 
            else
            {
                txtDescription.Text = string.Empty;
            }
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxMovies.SelectedItem is Movie selectedMovie && dpDate.SelectedDate is DateTime selectedDate)
            {
                RefreshAvailableSeats(GetAvailableSeats(selectedMovie, selectedDate));
            }
        }

        private void btnBookSeats_Click(object sender, RoutedEventArgs e)
        {
            if (lbxMovies.SelectedItem is Movie selectedMovie && dpDate.SelectedDate is DateTime selectedDate)
            {
                bool parsingRes = int.TryParse(tblkRequiredSeats.Text, out int requiredSeats);

                if (!parsingRes)
                {
                    MessageBox.Show("no strings have a number in the requiredSeats");
                    return;
                }

                if (requiredSeats <= 0)
                {
                    MessageBox.Show("you can't book 0 or a negative number of seats");
                }

                int availableSeats = GetAvailableSeats(selectedMovie, selectedDate);

                if (availableSeats - requiredSeats < 0)
                {
                    MessageBox.Show("too many seats");
                    return;
                }

                var newBooking = new Booking { BookingDate =  selectedDate, NumberOfTickets = requiredSeats, MovieID = selectedMovie.MovieID };
                using (var db = new MovieData())
                {
                    db.Bookings.Add(newBooking);
                    db.SaveChanges();
                }

                MessageBox.Show("Booking made");

                LoadMovies();
                RefreshAvailableSeats(availableSeats);
            }
            else
            {
                MessageBox.Show("Select a movie AND a date please");
            }
        }
    }
}
