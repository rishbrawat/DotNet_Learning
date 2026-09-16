using System;
using System.Globalization;

public class Arr
{
    static void Main(string[] args)
    {
        /*
         * an array is a data structure used to store a fixed size collection of elements of the same data type in single variable.
         * 
         * fixed size
         * zero indexed
         * same type
         */

        // array of frutis (strings)
        string[] fruits = { "Apple", "Mango", "Banana" };

        // array of integers integers
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // array elements are mutable
        fruits[0] = "peach";

        // length property: tells us how many items in the array
        Console.WriteLine($"fruits length: {fruits.Length}");

        // looping through an array
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"{fruit} ");
        }

        // using a for loop is best when there is fixed length or we know the length
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"number at index: {i} is {numbers[i]}");
        }

        // reverse the array
        Array.Reverse(numbers);
        foreach(int num in numbers)
        {
            Console.WriteLine($"number: {num}")
        }

    }
}