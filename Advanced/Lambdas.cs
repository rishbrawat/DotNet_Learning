using System;
using System.Collections.Generic;
using System.Linq;

// lambda functions are anonymous functions
class Lambdas
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

                                        // lambda, n is input and right side is the condtion that returns true or false
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

        foreach(var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}