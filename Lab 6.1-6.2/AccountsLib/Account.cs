using System;
using Account;

namespace AccountsLib
{
    public class Account
    {
        private int _id;
        public int ID => _id;

        private double _balance;
        public double Balance => _balance;

        internal Account(int accId)
        {
            _id = accId;
        }

        public void Deposit(double depositAmount)
        {
            if (depositAmount < 0)
                throw new ArgumentOutOfRangeException();
            _balance += depositAmount;
            Console.WriteLine($"New account {_id} balance after deposit is: {_balance}");
        }

        public void Withdraw(double withdrawAmount)
        {
            if (withdrawAmount > _balance)
                throw new ArgumentOutOfRangeException();
            _balance -= withdrawAmount;
            if (_balance < 0)
                throw new IsufficientFundsException();

            Console.WriteLine($"Account ID {_id} New balance for  after withdraw: {_balance}");
        }

        public void Transfer(Account secAccount, double transferAmount)
        {
            if (transferAmount > _balance)
                throw new ArgumentOutOfRangeException();
            secAccount._balance += transferAmount;
            Console.WriteLine("Transfer has been successful: ");
            Console.WriteLine($"Account ID {secAccount._id} New Balance after transfer is: {secAccount._balance}");
        }
    }

    public static class AccountFactory
    {
        private static int _initialId = 1;
        public static Account CreateAccount(double initialBalance)
        {
            Account newAccount = new Account(_initialId++);
            newAccount.Deposit(initialBalance);
            return newAccount;
        }
    }
}

