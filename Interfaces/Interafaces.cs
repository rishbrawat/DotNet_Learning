using System;

// Interface is a template that defines a set of capabilities such as methods and properties.
// The class that implements the interface must provide its own implementation.
// Interface names should start with 'I'.
public interface IBank
{
    // Property contract (classes implementing this must provide a Balance property)
    decimal Balance { get; }

    // Method contracts
    void Deposit(decimal amount);
    bool Withdraw(decimal amount);
}

// A class implementing the IBank interface
public class SavingsAccount : IBank
// Error prevention: In C#, interfaces are "implemented", not "inherited", but the syntax uses a colon (:) for both.
{
    private decimal _balance;

    // Implementing the Balance property from the interface
    public decimal Balance
    {
        get { return _balance; }
    }

    // Implementing the Deposit method
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Successfully deposited: ${amount}");
        }
    }

    // Implementing the Withdraw method
    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine($"Successfully withdrew: ${amount}");
            return true;
        }

        Console.WriteLine("Withdrawal failed: Insufficient funds or invalid amount.");
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an object using the interface type (Interface Polymorphism)
        IBank myAccount = new SavingsAccount();

        myAccount.Deposit(1000m);
        myAccount.Withdraw(300m);

        Console.WriteLine($"Current Balance: ${myAccount.Balance}");
    }
}