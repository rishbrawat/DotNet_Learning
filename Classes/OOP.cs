using System;
/*
 * object oriented programming
 * ___________________________
 * oop architecture provides us a way to write clean, maintainable and scalable code
 * it has 4 core principles
 */


/*
 * encapsulation: wrapping or bundling data and method in a single unit that is basically a class, restricting external access to the internal state.
 * it protects the object from entering an invalid state, like making a account number negative.
 * we obtain it through access modifiers- private, public combined with properties like get and set.
 * */
class BankAccount
{
    private decimal _Balance;
    public decimal Balance
    {
        get { return _Balance; }
        set { _Balance = value; } // for internal modification only
    }

    public void Deposit(decimal Amount)
    {
        if (Amount > 0)
        {
            _Balance += Amount;
        }
    }
}

// inheritance: allowing a class to have properties and methods of other class
class Animal
{
    public string Name { get; set; }
    public void Eat()
    {
        Console.WriteLine($"{Name} is eating\n");
    }
}
class Dog: Animal
{
    public void Bark()
    {
        Console.WriteLine($"{Name} is barking!\n");
    }
}

// polymorphism: one name many forms, by method overloading and method overridning
class Animals
{
    // method overriding: : A derived class provides its own specific implementation of a method already defined in its base class
    // virtual is necessary for method overriding
    public virtual void MakeSound()
    {
        Console.WriteLine("Some Sound");
    }
    // method overloading: same method but different parameters
    public int AddNums(int a, int b)
    {
        return a + b;
    }
}

class Cat: Animals
{
    // to override a method we write 'override' keyword before type specifier
    public override void MakeSound()
    {
        Console.WriteLine("Meow\n");
    }

    public int AddNums(int a, int b, int c)
    {
        return a + b + c;
    }
}

/*
 * abstract class or abstraction: hiding internal implementation details and showing only what is necessary.
 */
abstract class Vechicle2
{
    public abstract void StartEngine();
}
class Car2 : Vechicle2
{
    public override void StartEngine()
    {
        Console.WriteLine("Engine started!");
    }
}

class MainClass
{
    static void Main(string[] args)
    {  // we create an object of the child class
        Dog Dog1 = new Dog();
        Dog1.Name = "Minta";
        Dog1.Bark();
    }
}