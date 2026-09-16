using System;

/**
 * class is a template to create custom data structure, it defines what variables(data) and methods(action) an entity will have, but it does not hold any actual data on its own.
 * */

class Car
{
    // data the entity will have
    // get allows us to retrieve or access these values from the outside
    // set allows us to modify these values from outside
    string Brand { get; set; }
    string Model{get; set;}
    int Speed { get; set; }
    int YearOfManufacture { get; set; }

    // set up a parameterized constructor, it is automatically called when we create an object of that class
    public Car(String BrandName, String ModelName, int MaxSpeed, int ManufacturYear)
    {
        Brand = BrandName;
        Model = ModelName;
        Speed = MaxSpeed;
        YearOfManufacture = ManufacturYear;
    }

    // methods/action on that data or for entitity
    void drive()
    {
        Console.WriteLine($"The car is now running at {Speed}!");
    }
    void CarDetails()
    {
        Console.WriteLine($"Car Brand: {Brand} \nCar Model: {Model} \nSpeed: {Speed} \nYearOfManufacture: {YearOfManufacture}");
    }
    public static void Main()
    {
        Car FirstCar = new Car("Honda", "City", 185, 2021);
        Console.WriteLine(FirstCar.Speed);
    }
}