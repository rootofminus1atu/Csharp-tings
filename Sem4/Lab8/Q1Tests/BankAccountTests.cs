using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void SingleDepositTest()
        {
            decimal initialBalance = 100;
            decimal amount = 50;
            decimal expectedBalance = initialBalance + amount;
            BankAccount account = new(initialBalance);

            account.Deposit(amount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod()]
        public void MultipleDepositTest()
        {
            decimal initialBalance = 100;
            decimal a1 = 50;
            decimal a2 = 20;
            decimal a3 = 30;
            decimal expectedBalance = initialBalance + a1 + a2 + a3;
            BankAccount account = new(initialBalance);

            account.Deposit(a1);
            account.Deposit(a2);
            account.Deposit(a3);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod()]
        public void NewAccountTest()
        {
            BankAccount account = new();

            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod()]
        public void SufficientFundsTest()
        {
            decimal initialBalance = 100;
            decimal amount = 50;
            decimal expectedBalance = initialBalance - amount;
            BankAccount account = new(initialBalance);

            account.Withdraw(amount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod()]
        public void InsufficientFundsTest()
        {
            decimal initialBalance = 100;
            decimal amount = 150;

            BankAccount account = new(initialBalance);

            Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(amount));
        }

        [TestMethod()]
        public void WithdrawWithOverdraftTest()
        {
            decimal initialBalance = 100;
            decimal overdraftLimit = 50;
            decimal amount = 120;
            decimal expectedBalance = initialBalance - amount;
            BankAccount account = new(initialBalance, overdraftLimit);

            account.Withdraw(amount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod()]
        public void WithdrawExceedOverdraftTest()
        {
            decimal initialBalance = 100;
            decimal overdraftLimit = 50;
            decimal amount = 4200;

            BankAccount account = new(initialBalance, overdraftLimit);

            Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(amount));
        }
    }
}