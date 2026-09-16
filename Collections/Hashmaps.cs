using System;
using System.Collections.Generic;

// It stores data in key-value pairs. Keys must be unique, and they provide fast lookups, insertions and deletions with an average time complexity of O(1).
class DictionaryCol
{
    static void Main(string[] args)
    {
        // 1. Creation and Initialization
        Dictionary<int, string> employeeDirectory = new Dictionary<int, string>()
        {
            { 101, "Alice" },
            { 102, "Bob" }
        };

        // 2. Adding Elements
        // Add() method: Adds a key-value pair. Throws an ArgumentException if the key already exists.
        employeeDirectory.Add(103, "Charlie");

        // Indexer [] method: Can add or update. If the key exists, it updates the value. 
        // If it doesn't exist, it creates a new entry.
        employeeDirectory[104] = "Diana";
        employeeDirectory[101] = "Alice Updated"; // Updates key 101

        // 3. Accessing Elements
        // Accessing via indexer. Warning: Throws KeyNotFoundException if the key doesn't exist.
        string emp103 = employeeDirectory[103];
        Console.WriteLine($"Employee 103: {emp103}");

        // TryGetValue() is the safest way to access elements. It returns false instead of throwing an exception if the key is missing.
        if (employeeDirectory.TryGetValue(105, out string empName))
        {
            Console.WriteLine($"Found: {empName}");
        }
        else
        {
            Console.WriteLine("Key 105 not found safely via TryGetValue.");
        }

        // 4. Checking for Keys or Values
        // ContainsKey(): O(1) average time complexity because keys are hashed.
        bool hasKey102 = employeeDirectory.ContainsKey(102);
        
        // ContainsValue(): O(N) time complexity because it has to search through all values linearly.
        bool hasBob = employeeDirectory.ContainsValue("Bob");
        Console.WriteLine($"\nContains Key 102? {hasKey102}, Contains Value 'Bob'? {hasBob}");

        // 5. Iterating through a Dictionary
        Console.WriteLine("\nAll Employees in Directory:");
        foreach (KeyValuePair<int, string> kvp in employeeDirectory)
        {
            Console.WriteLine($"  ID: {kvp.Key}, Name: {kvp.Value}");
        }

        // 6. Removing Elements
        // Remove(key): Deletes the key-value pair. Returns true if successful. Time complexity: O(1) average.
        bool isRemoved = employeeDirectory.Remove(102);
        Console.WriteLine($"\nRemoved key 102? {isRemoved}. New Count: {employeeDirectory.Count}");

        // 7. Clear the Dictionary
        // Clear(): Removes all keys and values, setting Count to 0.
        employeeDirectory.Clear();
        Console.WriteLine($"Dictionary cleared. Count: {employeeDirectory.Count}");
    }
}