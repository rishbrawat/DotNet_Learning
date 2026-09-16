using System;

public class Methods
{
    // methods or functions allows us to wrap sequence of steps that we can perform without having to re-write same code again and again

    // method with single parameter
    static void GreetUser(string user)
    {
        Console.WriteLine($"Welcome: {user}");
    }

    static int AddNums(int a, int b)
    {
        return a + b;
    }

    static void Main(string[] args)
    {
        GreetUser("Rishabh");

        int result = AddNums(10, 15);
        Console.WriteLine($"Result: {result}");
    }
}