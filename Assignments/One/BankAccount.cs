using System;

class BankAccounts
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"deposited {amount}, new balance is {Balance}");
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        Console.WriteLine($"withdrew {amount}, remaining balance is {Balance}");
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"account holder: {AccountHolderName}, current balance: {Balance}");
    }

    static void Main(string[] args)
    {
        BankAccounts acc = new BankAccounts();
        acc.AccountNumber = "ACC123";
        acc.AccountHolderName = "Rishabh";
        acc.Balance = 5000m;

        acc.DisplayBalance();
        acc.Deposit(1500m);
        acc.Withdraw(2000m);
    }
}