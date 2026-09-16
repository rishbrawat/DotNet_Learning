using System;

/*
    exception handling is used to manage runtime errors, so the program wont crash unexpectedly.

    try: Encapsulates risky code.

    catch: Handles the error.

    finally: Guarantees execution of cleanup code (releasing unmanaged resources).

    throw: Allows you to enforce validation logic.
*/

class EHD
{
    static void Main(string[] args)
    {
        
        try
        {
            int a = 10;
            int b = 0;

            int result = a/b;
            Console.WriteLine($"Result: {result}"); 
        } catch(DivideByZeroException ex)
        {
            Console.WriteLine($"[Caught Specific Exception]: Cannot divide by zero.");
            Console.WriteLine($"  Message: {ex.Message}\n");
        }

        // multi level exception handling
        try
        {
            string[] fruits = { "Apple", "Banana" };
            string item = fruits[5]; // This throws an ArgumentOutOfRangeException
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[Caught ArgumentOutOfRange]: Index was out of bounds.");
        }
        catch (Exception ex) // General fallback (must always be placed *after* specific catch blocks)
        {
            Console.WriteLine($"[Caught General Exception]: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("[Finally Block]: Cleanup tasks completed.\n");
        }
    }
}