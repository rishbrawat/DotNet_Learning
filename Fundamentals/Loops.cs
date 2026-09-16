using System;

public class Loops
{
    public static void Main(string[] args)
    {
        // loops: allows to perform a certain task mutiple times without re-writing same code again and again

        // for loop: when index range is known
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Hello World\n");
        }

        // while loop: is a condition controlled
        int count = 3;
        while (count > 0)
        {
            Console.WriteLine($"Count: {count}");
            count--;
        }

        // do while checks atleast one codition
        int executed = 0;
        do
        {
            Console.WriteLine($"Executed: {executed+1} times but executed variable was set to {executed}");
        } while(executed > 0);



        
    }
}