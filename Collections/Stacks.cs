using System;
using System.Collections.Generic;

// Stack is a LIFO (Last-In First-Out) data structure. 
// Think of a stack of plates: the last plate you put on top is the first one you take off.
class StackCol
{
    static void Main(string[] args)
    {
        // Create a stack of integers
        Stack<int> numbersStack = new Stack<int>();

        // Push adds an element to the top of the stack. Time complexity: O(1) amortized.
        numbersStack.Push(10);
        numbersStack.Push(20);
        numbersStack.Push(30);

        Console.WriteLine($"Initial Stack Count: {numbersStack.Count}");

        // Peek() returns the top element *without* removing it from the stack.
        Console.WriteLine($"Peek (Top element): {numbersStack.Peek()}");

        // Pop removes and returns the element at the top of the stack. Time complexity: O(1).
        int removedItem = numbersStack.Pop();
        Console.WriteLine($"Popped item: {removedItem}");
        Console.WriteLine($"Count after Pop: {numbersStack.Count}");

        // Creating a stack using a collection initializer
        Stack<string> browserHistory = new Stack<string>(new[] { "Google", "GitHub", "StackOverflow" });

        // Iterate through the stack (Note: foreach iterates from top to bottom)
        Console.WriteLine("\nBrowser History (Top to Bottom):");
        foreach (string site in browserHistory)
        {
            Console.WriteLine($"  Site: {site}");
        }

        // Contains() checks if an item exists in the stack. Time complexity: O(N) linear search.
        bool hasGitHub = browserHistory.Contains("GitHub");
        Console.WriteLine($"\nDoes history contain 'GitHub'? {hasGitHub}");

        // Clear() removes all elements from the stack, setting Count to 0.
        browserHistory.Clear();
        Console.WriteLine($"Browser history cleared. Count: {browserHistory.Count}");
    }
}