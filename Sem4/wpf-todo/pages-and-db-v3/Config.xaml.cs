using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace pages_and_db_v3
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        private readonly Db db;

        public Config(Db db)
        {
            this.db = db;
            InitializeComponent();
            LoadTodoItems();
        }

        private void LoadTodoItems()
        {
            TodoListBox.ItemsSource = db.TodoItemsFromDb.ToList();
        }

        private void AddTodoButPage_Click(object sender, RoutedEventArgs e)
        {
            var addTodoWindow = new AddTodo(db);
            addTodoWindow.ShowDialog();
            LoadTodoItems();
        }

        private void RemoveTodo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is TodoItemFromDb todoItem)
            {
                Trace.WriteLine($"we found a todo {todoItem.Id} - {todoItem.Text}");
                db.TodoItemsFromDb.Remove(todoItem);
                db.SaveChanges();
                LoadTodoItems();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is TodoItemFromDb todoItem)
            {
                Trace.WriteLine($"editing {todoItem.Id} {todoItem.Text} {todoItem.IsCompleted} to TRUE");
                todoItem.IsCompleted = true;
                db.SaveChanges();
                LoadTodoItems();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is TodoItemFromDb todoItem)
            {
                Trace.WriteLine($"editing {todoItem.Id} {todoItem.Text} {todoItem.IsCompleted} to FALSE");
                todoItem.IsCompleted = false;
                db.SaveChanges();
                LoadTodoItems();
            }
        }
    }
}
