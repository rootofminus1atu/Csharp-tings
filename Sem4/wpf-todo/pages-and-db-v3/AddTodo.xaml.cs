using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace pages_and_db_v3
{
    /// <summary>
    /// Interaction logic for AddTodo.xaml
    /// </summary>
    public partial class AddTodo : Window
    {

        private readonly Db db;
        public AddTodo(Db db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string todoText = TodoNameTextBox.Text;

            if (!string.IsNullOrWhiteSpace(todoText))
            {
                var newTodoItem = new TodoItemFromDb { Text = todoText, IsCompleted = false };
                db.TodoItemsFromDb.Add(newTodoItem);
                db.SaveChanges();

                Close();
            }
            else
            {
                MessageBox.Show("Please enter a todo name.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
