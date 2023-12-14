using System;
using System.CodeDom;
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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> allAccounts = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Account a1 = new CurrentAccount(999, "Joe", "Biden", 120);
            Account a2 = new SavingsAccount(888, "Jeff", "The Killer", 830);

            allAccounts = new List<Account>() { a1, a2 };


            cbxCurrentAccounts.IsChecked = true;
            cbxSavingsAccounts.IsChecked = true;
        }

        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account? chosenAccount = lbxAccounts.SelectedItem as Account;

            if (chosenAccount == null)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtBalance.Text = "";
                return;
            }

            txtFirstName.Text = chosenAccount.FirstName;
            txtLastName.Text = chosenAccount.LastName;
            txtBalance.Text = $"{chosenAccount.Balance}";
        }

        private void ManageCheckboxes()
        {
            bool? saChecked = cbxCurrentAccounts.IsChecked;
            bool? caChecked = cbxSavingsAccounts.IsChecked;

            List<Account> displayedAccounts = (saChecked, caChecked) switch
            {
                (false, false or null) => new(),
                (true, false or null) => allAccounts.Where(a => a is SavingsAccount).ToList(),
                (false or null, true) => allAccounts.Where(a => a is CurrentAccount).ToList(),
                (true, true) => allAccounts,
                _ => new()
            };

            lbxAccounts.ItemsSource = displayedAccounts;
            lbxAccounts.Items.Refresh();
        }

        private void cbxCurrentAccounts_Unchecked(object sender, RoutedEventArgs e)
        {
            ManageCheckboxes();
        }

        private void cbxCurrentAccounts_Checked(object sender, RoutedEventArgs e)
        {
            ManageCheckboxes();
        }

        private void cbxSavingsAccounts_Checked_1(object sender, RoutedEventArgs e)
        {
            ManageCheckboxes();
        }

        private void cbxSavingsAccounts_Unchecked_1(object sender, RoutedEventArgs e)
        {
            ManageCheckboxes();
        }

        private void HandleTransaction(Action<Account, double> transactionAction)
        {
            Account? chosenAccount = lbxAccounts.SelectedItem as Account;

            if (chosenAccount == null)
            {
                MessageBox.Show("Pick an account first");
                return;
            }

            string amountStr = tbxTransactionAmount.Text;
            bool parsingResult = double.TryParse(amountStr, out double amount);

            if (!parsingResult)
            {
                MessageBox.Show("Not a valid transaction amount");
                return;
            }

            try
            {
                transactionAction(chosenAccount, amount);
                txtBalance.Text = $"{chosenAccount.Balance}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transaction failed: {ex.Message}");
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            HandleTransaction((chosenAccount, amount) => chosenAccount.Deposit(amount));
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            HandleTransaction((chosenAccount, amount) => chosenAccount.Withdraw(amount));
        }
    }
}
