using System;

public class LoanAccount : BankAccount
{
    private decimal interestRate;

    public LoanAccount(string accountNumber, string accountHolderName, decimal initialBalance, decimal interestRate)
        : base(accountNumber, accountHolderName, initialBalance)
    {
        this.interestRate = interestRate;
    }

    public void CalculateInterest(int months)
    {
        decimal interest = Balance * interestRate * months / 12;
        Console.WriteLine($"Interest calculated for {months} months: {interest:C}");
    }
}
