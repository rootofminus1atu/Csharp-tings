using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Expense> expenses = new ObservableCollection<Expense>()
        {
            Expense.RandomExpense(),
            Expense.RandomExpense(),
            Expense.RandomExpense(),
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expense newExpense = Expense.RandomExpense();

            expenses.Add(newExpense);
            double total = Math.Round(expenses.Sum(expense => expense.Cost), 2);
            txtTotalCost.Text = $"Total Cost: {total}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstExpenses.ItemsSource = expenses;
            double total = Math.Round(expenses.Sum(expense => expense.Cost), 2);
            txtTotalCost.Text = $"Total Cost: {total}";
        }
    }
}
