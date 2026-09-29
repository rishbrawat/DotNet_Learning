using System;
using System.Collections.Generic;
using System.Linq;

// linq stands for language integrated query
// linq lets you query and tranform data using c# syntax

// instead of manually filtering or working on data using loops, sorting, linq provides several methods to work on the data

class Ln
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> {1,2,3,4,5,5,6,8,9};
        List<int> evens = new List<int>();



        // manually filtering even numbers and then storing it in our evens array
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
            {
                evens.Add(num);
            }
        }

        foreach (int even in evens)
        {
            Console.WriteLine(even);
        }

        // now with linq we can do. enumrable cuz, it will return ienumrable object
        IEnumerable<int> evenNumbers = numbers.Where(num => num % 2 == 0);
        foreach(int even in evenNumbers)
        {
            Console.WriteLine(even);
        }

        // common linq methods
        // where - used to filter a sequence and only returns elements that satisfy the condition, returns IEnumrable object. DECIDES WHICH ELEMENTS REMAIN

        List<int> numbersArray = new List<int> {1,2,3,4,5,6,7,8,9,10};
        IEnumerable<int> oddNums = numbersArray.Where(n => n %2 != 0);

        // select = transforms each element into other form, converts objects to names, numbers to square, returns IEnumrable<TResult>, DECIDES WHAT EACH ELEMENT BECOMES
        IEnumerable<int> squared = numbersArray.Select( n => n * n);

        // orderby : to order elememts in ascending format
        var ascendingElements = numbersArray.OrderBy(n => n);
        var descendingElements = numbersArray.OrderByDescending(n => n);


        // checks if any number exists or not
        bool hasNumber = numbersArray.Any();
        // we can also write conditions in it
        bool hasEven = numbersArray.Any(n => n % 2 == 0);


        // count() count how many elements are there, returns an integer
        // useful in pagination, validation, reporting, stats
        int totalCount = numbersArray.Count();
        // now we give it a condition
        int evenCount = numbersArray.Count(n => n % 2 == 0);

        // first(): get the first element
        int first = numbersArray.First();
        // adding condition to it
        int firstEven = numbersArray.First(n => n % 2 == 0); // if nothing matches, it will throw an exception

        // firstOrDefault() -> give me the first matching element or give me default
        int number = numbersArray.FirstOrDefault(n => n >=100); // for int the default is 0, for a reference type, it can be null or User Object

        // single= for single matching element, must be one matching element
        int matching = numbersArray.Single(n => n == 5); // will throw exception if there are two matches

        // contains() = checks if the sequence contains the value of not
        bool exists = numbersArray.Contains(5); // returns boolean val

        // distinct() = removes all duplicates
        var uniqueNumbers = numbersArray.Distinct();

        // pagination related
        var data = numbersArray.Skip(2).Take(4);
        
        // toList -> converting into a list
        List<int> oddList = oddNums.ToList();

    }
}