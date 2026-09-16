using System;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    static void Main(string[] args)
    {
        Student s1 = new Student { StudentId = 1, Name = "Rishabh", Age = 21 };
        Student s2 = new Student { StudentId = 2, Name = "Amit", Age = 20 };

        Console.WriteLine("student details are here:");
        Console.WriteLine($"id: {s1.StudentId}, name: {s1.Name}, age: {s1.Age}");
        Console.WriteLine($"id: {s2.StudentId}, name: {s2.Name}, age: {s2.Age}");
    }
}