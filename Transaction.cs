using System;

public enum TransactionType
{
    Deposit,
    Withdrawal
}

public class Transaction
{
    public decimal Amount { get; }
    public DateTime Timestamp { get; }
    public TransactionType Type { get; }

    public Transaction(decimal amount, TransactionType type)
    {
        Amount = amount;
        Type = type;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        string transactionType = Type == TransactionType.Deposit ? "Deposit" : "Withdrawal";
        return $"{Timestamp} - {transactionType}: {Amount:C}";
    }
}
