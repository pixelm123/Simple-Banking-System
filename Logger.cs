using System;

public class Logger
{
    public void LogTransaction(string message)
    {
        Console.WriteLine($"[Transaction Log] {message}");
    }

    public void LogError(string errorMessage)
    {
        Console.WriteLine($"[Error Log] {errorMessage}");
    }

    
}
