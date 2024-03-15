using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public decimal OverdraftLimit { get; set; }

        public BankAccount() { }

        public BankAccount(decimal balance)
        {
            Balance = balance;
            OverdraftLimit = 0;
        }

        public BankAccount(decimal balance, decimal overdraftLimit)
        {
            Balance = balance;
            OverdraftLimit = overdraftLimit;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            decimal availableBalance = Balance + OverdraftLimit;

            if (amount > availableBalance)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
        }
    }
}
