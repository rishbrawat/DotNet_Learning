using System;
using System;

namespace InheritanceTypes
{
    // inheritance lets a class take properties and methods from another class so u dont have to write 
    // the same code over and over again. c sharp supports a few main types of inheritance.

    // 1. single inheritance: one child class inherits from a single parent class.
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("eating...");
        }
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }

    // 2. multilevel inheritance: a class inherits from a derived class, creating a chain 
    // (parent -> child -> grandchild).
    class Puppy : Dog
    {
        public void Weep()
        {
            Console.WriteLine("weeping...");
        }
    }

    // 3. hierarchical inheritance: multiple child classes inherit from the same single parent class.
    class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("meowing...");
        }
    }

    // 4. multiple inheritance using interfaces: c sharp does not allow a class to inherit from 
    // multiple classes directly (to prevent the diamond problem), but u can implement multiple interfaces 
    // to achieve multiple inheritance behavior.
    interface IFlyable
    {
        void Fly();
    }

    interface ISwimmable
    {
        void Swim();
    }

    class Duck : Animal, IFlyable, ISwimmable
    {
        public void Fly()
        {
            Console.WriteLine("duck is flying...");
        }

        public void Swim()
        {
            Console.WriteLine("duck is swimming...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("single inheritance");
            Dog myDog = new Dog();
            myDog.Eat(); // inherited from Animal
            myDog.Bark(); // own method

            Console.WriteLine("\n multilevel inheritance ");
            Puppy myPuppy = new Puppy();
            myPuppy.Eat();  // inherited from Animal via Dog
            myPuppy.Bark(); // inherited from Dog
            myPuppy.Weep(); // own method

            Console.WriteLine("\n hierarchical inheritance ");
            Cat myCat = new Cat();
            myCat.Eat();  // inherited from Animal
            myCat.Meow(); // own method

            Console.WriteLine("\n multiple inheritance via interfaces ");
            Duck myDuck = new Duck();
            myDuck.Eat();  // from base class Animal
            myDuck.Fly();  // from interface IFlyable
            myDuck.Swim(); // from interface ISwimmable

        }
    }
}