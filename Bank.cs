using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

public class Bank : ISubject
{
    private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
    private List<IObserver> observers = new List<IObserver>();

    private static Bank instance;

    private Bank() { }

    public static Bank GetInstance()
    {
        if (instance == null)
        {
            instance = new Bank();
        }
        return instance;
    }

    public void AddAccount(BankAccount account)
    {
        if (!accounts.ContainsKey(account.AccountNumber))
        {
            accounts.Add(account.AccountNumber, account);
            Console.WriteLine($"Account {account.AccountNumber} added successfully.");
        }
        else
        {
            Console.WriteLine($"Account {account.AccountNumber} already exists.");
        }
    }

    public BankAccount GetAccount(string accountNumber)
    {
        return accounts.ContainsKey(accountNumber) ? accounts[accountNumber] : null;
    }

    public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        if (fromAccount == null || toAccount == null)
        {
            Console.WriteLine("Invalid account(s).");
            return;
        }

        if (fromAccount.Balance < amount)
        {
            Console.WriteLine("Insufficient funds for transfer.");
            return;
        }

        fromAccount.Withdraw(amount);
        toAccount.Deposit(amount);
        Console.WriteLine($"Transfer of {amount:C} from {fromAccount.AccountNumber} to {toAccount.AccountNumber} successful.");
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}
