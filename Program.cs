using System;

class BankAccount
{
    private string accountHolderName;
    private string accountNumber;
    private decimal balance;

    public BankAccount(string name, string number, decimal initialBalance)
    {
        accountHolderName = name;
        accountNumber = number;
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"{amount} deposited successfully.");
    }

    public void Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"{amount} withdrawn successfully.");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Balance: {balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("John Doe", "123456", 1000.00m);
        BankAccount account2 = new BankAccount("Jane Smith", "654321", 2000.00m);

        // Perform operations on accounts
        account1.CheckBalance();
        account1.Deposit(500.00m);
        account1.Withdraw(200.00m);
        account1.CheckBalance();

        account2.CheckBalance();
        account2.Withdraw(3000.00m); // This should show an error message
    }
}
