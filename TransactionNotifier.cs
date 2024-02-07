using System;

public class TransactionNotifier : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is BankAccount account)
        {
            Console.WriteLine($"Account {account.AccountNumber} has a new transaction.");
        }
    }
}
