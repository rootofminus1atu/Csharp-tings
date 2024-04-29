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
    /// Interaction logic for AddTodo.xaml
    /// </summary>
    public partial class AddTodo : Page
    {
        private readonly ObservableCollection<TodoItem> todoItems;

        public AddTodo(ObservableCollection<TodoItem> todoItems)
        {
            this.todoItems = todoItems;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string todoText = TodoNameTextBox.Text;

            todoItems.Add(new TodoItem { Text = todoText });

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
