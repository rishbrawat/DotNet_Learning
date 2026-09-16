using System;

public class Conditions
{
    public static void Main(String[] args)
    {
        // conditions controls the flow of the program
        // if condition -> checks a condition
        int age = 20;
        if (age > 18)
        {
            Console.WriteLine("You are eligible for entrance!\n");
        }
        // else if is just checking alternative condition on an existing condition if block
        else if (age < 18)
        {
            Console.WriteLine("You are not eligible for entrance!\n");
        }
        // else works like, if certain condition is not true, then it will come here and this code block will get executed
        else
        {
            Console.WriteLine("Either age was not entered correctly or its invalid!");
        }


        // ternary operator: basically condition checking shorthand from if else to ? and :
        string Status = (age > 18) ? "You are eligible for entrance!\n": "You are not eligible for entrance!\n";
        Console.WriteLine(Status);  

    }
}