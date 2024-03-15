using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Q1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            // Arrange
            decimal initialBalance = 100;
            decimal depositAmount = 50;
            decimal expectedBalance = initialBalance + depositAmount;

            BankAccount account = new BankAccount(initialBalance);

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}
