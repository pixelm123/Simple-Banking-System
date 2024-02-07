using System;
using System.Linq;

public class BankManager
{
    private Bank bank;

    public BankManager(Bank bank)
    {
        this.bank = bank;
    }

    public void AddAccount(string accountNumber, string accountHolderName, decimal initialBalance)
    {
        BankAccount account = new BankAccount(accountNumber, accountHolderName, initialBalance);
        bank.AddAccount(account);
        Console.WriteLine($"Account {accountNumber} added successfully by Bank Manager.");
    }

    public void RemoveAccount(string accountNumber)
    {
        BankAccount account = bank.GetAccount(accountNumber);
        if (account != null)
        {
            bank.RemoveAccount(account);
            Console.WriteLine($"Account {accountNumber} removed successfully by Bank Manager.");
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }


    public void ViewBankStatistics()
    {
        decimal totalBalance = bank.GetAllAccounts().Sum(a => a.Balance);
        int totalAccounts = bank.GetAllAccounts().Count;

        Console.WriteLine($"Total Accounts: {totalAccounts}");
        Console.WriteLine($"Total Balance: {totalBalance:C}");
    }
}
