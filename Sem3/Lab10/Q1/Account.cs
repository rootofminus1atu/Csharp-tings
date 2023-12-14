using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal abstract class Account
    {
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public DateTime InterestDate { get; set; }

        public Account(int accountNumber, string firstName, string lastName, double balance)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            InterestDate = DateTime.Now;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Cannot deposit less than 0 money.");
            }

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Cannot withdraw less than 0 money.");
            }

            if (amount > Balance)
            {
                throw new Exception("Not enough funds left in your bank account.");
            }

            Balance -= amount;
        }

        public abstract double CalculateInterest();

        public override string ToString()
        {
            return $"{AccountNumber} - {FirstName}, {LastName}";
        }
    }

    internal class CurrentAccount : Account
    {
        public double InterestRate => 0.03;

        public CurrentAccount(int accountNumber, string firstName, string lastName, double balance)
            : base(accountNumber, firstName, lastName, balance) { }

        public override double CalculateInterest()
        {
            // if last year
            if ((DateTime.Now - InterestDate).TotalDays < 365)
            {
                throw new Exception("Interest can only be applied once a year.");
            }

            InterestDate = DateTime.Now;
            return Balance * InterestRate;
        }
    }

    internal class SavingsAccount : Account
    {
        public double InterestRate => 0.06;

        public SavingsAccount(int accountNumber, string firstName, string lastName, double balance)
            : base(accountNumber, firstName, lastName, balance) { }

        public override double CalculateInterest()
        {
            // if last year
            if ((DateTime.Now - InterestDate).TotalDays < 365)
            {
                throw new Exception("Interest can only be applied once a year.");
            }

            InterestDate = DateTime.Now;
            return Balance * InterestRate;
        }
    }
}
