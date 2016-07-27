using System;
using System.Linq.Expressions;
using AccountsLib;

namespace Account
{
    class Program
    {
        static void Main()
        {
            var account = AccountFactory.CreateAccount(1000);
            var account2 = AccountFactory.CreateAccount(900);

            try
            {
                account.Withdraw(1000000);
            }
            catch (IsufficientFundsException)
            {
                Console.WriteLine("Custom Exception - Insufficient Funds");
            }

            try
            {
                account.Deposit(50);
                account.Withdraw(1000000);
                account.Transfer(account2, 4000);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Insufficiend Funds");
            }


        }
    }
}
