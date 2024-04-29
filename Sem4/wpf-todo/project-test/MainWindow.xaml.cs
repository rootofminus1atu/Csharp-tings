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

namespace project_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // getting all open windows
            // doing that so that later we could allow the user to pick a configuration for a given open application
            // for example if they have Discord and Minecraft open, those 2 should show up from a dropdown
            // and then the user can pick a configuration for them
            // for example for Minecraft they can pick the chat button to be 'T'
            // while for discord the chat button would be 'Enter'
            var openWindowProcesses = Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer");

            // debug printing
            foreach (var window in openWindowProcesses)
            {
                Trace.WriteLine(window.ProcessName);
            }
        }
    }
}
