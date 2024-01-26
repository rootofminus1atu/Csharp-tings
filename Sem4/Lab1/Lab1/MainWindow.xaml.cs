using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Band> bands = new()
        {
            new RockBand("Party Rockers", 2000, new List<string>() { "m1", "m2" }, new List<Album>
            {
                new Album("Fiery Star"),
                new Album("Thunderstruck"),
                new Album("Epic Riffs")
            }),
            new RockBand("Crawling Skins", 1900, new List<string>() { "m1", "m2", "bob" }, new List<Album>
            {
                new Album("Sonic Waves"),
                new Album("Lost Souls"),
            }),
            new RockBand("Goatstein", 280, new List<string>() { "m1", "m2" }, new List<Album>
            {
                new Album("Mountain Melodies"),
                new Album("Cavern Calls"),
                new Album("Rocky Road"),
                new Album("Guitar Dreams")
            }),
            new PopBand("Party Poppers", 2012, new List<string>() { "m1", "m2" }, new List<Album>
            {
                new Album("Pop Paradise"),
                new Album("Dance Delight")
            }),
            new IndieBand("Nesians", 2001, new List<string>() { "m1", "m2" }, new List<Album>
            {
                new Album("Dreamy Days")
            }),
            new IndieBand("They Exist", 1984, new List<string>() { "m1", "m2", "joe" }, new List<Album>
            {
                new Album("Shadow Serenade"),
                new Album("Existential Echo"),
                new Album("Indie Vibes")
            }),
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayItems(List<Band> items)
        {
            items.Sort();

            lbxBands.ItemsSource = items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxGenre.ItemsSource = new List<string>() { "All", "Rock", "Pop", "Indie" };

            DisplayItems(bands);
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxBands.SelectedItem is not Band chosenBand)
            {
                txtName.Text = "Name:";
                txtFormed.Text = "Formed:";
                txtMembers.Text = "Members:";
                lbxAlbums.ItemsSource = null;
                return;
            }

            Trace.WriteLine(chosenBand.ToString());

            txtName.Text = $"Name: {chosenBand.BandName}";
            txtFormed.Text = $"Formed: {chosenBand.YearFormed}";
            txtMembers.Text = $"Members: {chosenBand.MembersStr}";

            lbxAlbums.ItemsSource = chosenBand.Albums;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedGenre = cbxGenre.SelectedItem as string;

            if (selectedGenre is null or "All")
            {
                DisplayItems(bands);
                return;
            }

            List<Band> filteredBands = bands
                .Where(b => b.GetType().Name ==  $"{selectedGenre}Band")
                .ToList();

            DisplayItems(filteredBands);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lbxBands.SelectedItem is not Band chosenBand)
            {
                MessageBox.Show("Select a band to save.");
                return;
            }


            string filePath = @"../../../report.txt";

            try
            {
                File.WriteAllText(filePath, chosenBand.GenerateReport());

                MessageBox.Show("Data saved in report.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
