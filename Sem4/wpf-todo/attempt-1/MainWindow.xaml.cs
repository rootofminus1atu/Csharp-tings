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

namespace attempt_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            TodoListBox.ItemsSource = todoItems;
        }

        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            string newTodoText = NewTodoTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newTodoText))
            {
                todoItems.Add(new TodoItem { Text = newTodoText });
                NewTodoTextBox.Clear();
            }
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
