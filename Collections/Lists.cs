using System;
using System.Collections.Generic;
using System.Globalization;

// list is a dynamic sized array, automatically resizes itself
class ListCol
{
    static void Main(string[] args)
    {
        // create a list of 5 numbers
        List<int> Numbers = new List<int> {1,2,3,4,5};
        
        // creating a string list
        List<string> fruits = new List<string> {"apple", "mango", "papaya"};

        // add an element to it
        fruits.Add("grapes");

        // to append range of items we use AddRange()
        fruits.AddRange(["Peach","banana"]);

        foreach (string fruit in fruits)
        {
            Console.WriteLine($"fruit: {fruit}");
        }

        // remove an element, returns true if removed successfully
        fruits.Remove("Peach");

        // removeat index remove the element at the specific index
        fruits.RemoveAt(0);

        // insert an element at specific index
        fruits.Insert(0, "Jaamun");
        PrintList("After Insert at index 0:", fruits);

        // reverse the list
        Numbers.Reverse();

        // sort the list
        Numbers.Sort();

        // clear the list
        Numbers.Clear();
    }
    static void PrintList(string title, List<string> list)
    {
        Console.WriteLine(title);
        Console.WriteLine("  [" + string.Join(", ", list) + "]");
        Console.WriteLine($"  Count: {list.Count}, Capacity: {list.Capacity}\n");
    }

}
