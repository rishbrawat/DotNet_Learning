using System;

// Interface is a template that defines a set of capabilities such as methods and properties.
// The class that implements the interface must provide its own implementation.
// Interface names should start with 'I'.
// and interfaces are same to abstract classes but, it allows multiple inheritance
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
{
    private decimal _balance;

    // implementing the Balance property from the interface
    public decimal Balance
    {
        get { return _balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Successfully deposited: ${amount}");
        }
    }

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