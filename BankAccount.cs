using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;


public class BankAccount : ISubject
{
    public string AccountNumber { get; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; private set; }
    private List<Transaction> transactions = new List<Transaction>();
    private List<IObserver> observers = new List<IObserver>();

    public BankAccount(string accountNumber, string accountHolderName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount should be greater than zero.");
            return;
        }

        Balance += amount;
        transactions.Add(new Transaction(amount, TransactionType.Deposit));
        NotifyObservers();
        Console.WriteLine($"{amount:C} deposited successfully.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount should be greater than zero.");
            return;
        }

        if (Balance < amount)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        Balance -= amount;
        transactions.Add(new Transaction(amount, TransactionType.Withdrawal));
        NotifyObservers();
        Console.WriteLine($"{amount:C} withdrawn successfully.");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Balance: {Balance:C}");
    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine($"Transaction History for Account Number: {AccountNumber}");
        foreach (var transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
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
