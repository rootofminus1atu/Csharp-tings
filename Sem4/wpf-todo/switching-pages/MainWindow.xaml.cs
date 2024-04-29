using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace switching_pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TodoItem> TodoItems { get; } = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            // MainFrame.Navigate(new Uri("Config.xaml", UriKind.Relative));
            MainFrame.Navigate(new Config(TodoItems));
        }
    }
}
