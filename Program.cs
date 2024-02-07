
using System;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = Bank.GetInstance();

        BankAccount account1 = new BankAccount("123456", "John Doe", 1000.00m);
        BankAccount account2 = new BankAccount("654321", "Jane Smith", 2000.00m);

        bank.AddAccount(account1);
        bank.AddAccount(account2);


        account1.Attach(new TransactionNotifier());
        account2.Attach(new TransactionNotifier());

        account1.CheckBalance();
        account1.Deposit(500.00m);
        account1.Withdraw(200.00m);
        account1.CheckBalance();
        account1.PrintTransactionHistory();

        Console.WriteLine();

        account2.CheckBalance();
        account2.Withdraw(3000.00m);
        account2.CheckBalance();
        account2.PrintTransactionHistory();

        Console.WriteLine();

        bank.Transfer(account1, account2, 200.00m);
        account1.PrintTransactionHistory();
        account2.PrintTransactionHistory();
    }
}
