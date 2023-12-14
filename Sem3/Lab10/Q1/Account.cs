using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal abstract class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public DateTime InterestDate { get; set; }

        public void Deposit(double amount)
        {
            if (amount < 0) return;

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0) return;

            if (amount < Balance) return;

            Balance -= amount;
        }

        public abstract double CalculateInterest();
    }

    internal class CurrentAccount : Account
    {
        public double InterestRate => 0.03;
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
