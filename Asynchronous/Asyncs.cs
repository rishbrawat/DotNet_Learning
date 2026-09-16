using System;
using System.Threading.Tasks;

class Asyncs
{
    static async Task Main(string[] args)
    {
        /*
            similiar to javascript, async code means, the execution flow of the program wont be stopped while the resources will continue to fetch on macro stack.

            async is applied to a method, means that it contains asynchronous operation and allows users to have wait operation inside it.

            await: pauses the execution of async code untill the awaited task is finished
        */

        Console.WriteLine("starting work...");
        await DoSomething();
        Console.WriteLine("done");
    } 
    static async Task DoSomething()
    {
        await Task.Delay(2000); // 2000ms means 2seconds
        Console.WriteLine("Task compelted in 2seconds");
    }
}