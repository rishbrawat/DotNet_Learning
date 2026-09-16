using System;
using System.Collections.Generic;


namespace DelegatesEventsPredicates
{
    // a delegate is basicly a type-safe function pointer. 
    // u define a signature, and any method that matches it can be assigned to the delegate variable.
    public delegate void LogHandler(string message);

    class Program
    {
        // this method matches the LogHandler delegate signature
        static void PrintToConsole(string msg)
        {
            Console.WriteLine("[Console]: " + msg);
        }

        static void PrintToUppercase(string msg)
        {
            Console.WriteLine("[Upper]: " + msg.ToUpper());
        }

        // events are built on top of delegates. they provide a publishe subscriber model.
        // only the publisher class can trigger the event, keeping things secure.
        public class Button
        {
            // event using standard EventHandler delegate type
            public event EventHandler Clicked;

            public void SimulateClick()
            {
                Console.WriteLine("\nUser clicked the button...");  
                
                // check if anyone subscribed before firing the event to avoid null ref exception
                if (Clicked != null)
                {
                    Clicked(this, EventArgs.Empty);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" deletgrate demo ");
            
            // instanciate delegate and point it to our method
            LogHandler logger = PrintToConsole;
            logger("hello from single delegate!");

            // multicasting: u can add multiple methods to the same delegate chain using +
            logger += PrintToUppercase;
            logger("this will call both methods back to back.");


            Console.WriteLine("\nevent");
            
            Button myButton = new Button();

            // subscribers hook up to the event using the '+=' operator
            myButton.Clicked += (sender, e) => {
                Console.WriteLine("Subscriber 1: Button click listend successfully!");
            };

            myButton.Clicked += (sender, e) => {
                Console.WriteLine("Subscriber 2: Updating UI because button was pressed.");
            };

            // trigger the event
            myButton.SimulateClick();


            Console.WriteLine("\npredicate");
            
            // a predicate is just a built-in delegate that always takes one input and returns a boolean (bool).
            // its super handy when filtering lists or searching collections.
            List<int> numbers = new List<int> { 10, 15, 20, 25, 30, 35, 40 };

            // define a predicate using lambda expression (Predicate<int> is basicly Func<int, bool>)
            Predicate<int> isGreaterThanTwenty = n => n > 20;

            // pass the predicate into FindAll method
            List<int> results = numbers.FindAll(isGreaterThanTwenty);

            Console.WriteLine("Numbers greater than 20 found via predicate:");
            foreach (var num in results)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }
    }
}