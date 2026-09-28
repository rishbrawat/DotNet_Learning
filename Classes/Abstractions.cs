using System;

namespace DotNet_Learning.Classes
{
    // abstraction: abstraction means hiding implementation details and showing only whats necessary.
    // to achieve abstraction we can do it using either Interfaces or Abstract classes.

    public abstract class Vehicle
    {
        public abstract void StartEngine();
        public void StopEngine()
        {
            Console.WriteLine("Engine stopped!\n");
        }
    }

    public class Car : Vehicle
    {
        // override is used to replace implementation of an inherited virutal or abstract member.
        public override void StartEngine()
        {
            Console.WriteLine("Engine Started!\n");
        }
    }

    // abstraction using interfaces
    /**
        an interface is a reference type that defines a set of members that a class or struct can implement, it specifies what members an implementing type must provide, without defining the instance state of that type.
     */

    interface IAnimal
    {
        void MakeSound();
    }
    class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Bow bow");
        }
    }
    public class Mains
    {
        static void Main(string[] args)
        {
            Car Honda = new Car();
            Honda.StartEngine();
        }

    }
}
    

