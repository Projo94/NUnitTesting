using Bank;
using NUnit.Framework;
using System;

namespace BankNUnitTests
{
    public class BankAccountTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
            //ARRANGE
            account = new BankAccount(1000);
        }

        [Test]
        public void AddingFundsUpdatesBalance()
        {
            //ACT
            account.Add(500);

            //ASSERT
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void AddingNegativeFundsUpdatesBalance()
        {
            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
        }

        [Test]
        public void WithdrawingFundsUpdatesBalance()
        {
            //ACT
            account.Withdraw(500);

            //ASSERT
            Assert.AreEqual(500, account.Balance);
        }


        [Test]
        public void WithdrawingNegativeFundsUpdatesBalance()
        {
            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        [Test]
        public void WithdrawingMoreThanBalanceThrows()
        {
            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Test]
        public void TransferingFundsUpdatesBothAccounts()
        {
            var otherAccount = new BankAccount(500);

            //ACT
            account.TransferFundsTo(otherAccount, 300);

            //ASSERT
            Assert.AreEqual(700, account.Balance);
            Assert.AreEqual(800, otherAccount.Balance);
        }

        [Test]
        public void TransferToNonExistingAccountThrows()
        {
            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}