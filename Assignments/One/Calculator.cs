using System;

class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter first number:");
        // Converting cuz Readline will return a string hehe
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("enter operator (+, -, *, /):");
        string op = Console.ReadLine();

        Console.WriteLine("enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        if (op == "+")
        {
            result = num1 + num2;
            Console.WriteLine($"result is: {result}");
        }
        else if (op == "-")
        {
            result = num1 - num2;
            Console.WriteLine($"result is: {result}");
        }
        else if (op == "*")
        {
            result = num1 * num2;
            Console.WriteLine($"result is: {result}");
        }
        else if (op == "/")
        {
            if (num2 == 0)
            {
                Console.WriteLine("cant divide by zero");
            }
            else
            {
                result = num1 / num2;
                Console.WriteLine($"result is: {result}");
            }
        }
        else
        {
            Console.WriteLine("invalid operator entered");
        }
    }
}