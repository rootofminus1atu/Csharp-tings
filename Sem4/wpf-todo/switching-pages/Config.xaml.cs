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
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        private readonly ObservableCollection<TodoItem> todoItems;
        public Config(ObservableCollection<TodoItem> todoItems)
        {
            InitializeComponent();
            this.todoItems = todoItems;
            TodoListBox.ItemsSource = todoItems;
        }

        private void AddTodoButPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTodo(todoItems));
        }

        private void RemoveTodo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is TodoItem todoItem)
                {
                    todoItems.Remove(todoItem);
                }
            }
        }
    }
}
