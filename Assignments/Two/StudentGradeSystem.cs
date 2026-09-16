using System;
using System.Collections.Generic;

// base class to show inheritance concept
class Person
{
    public string Name { get; set; }
}

class Student1 : Person
{
    public int StudentId { get; set; }

    // encapsulation using a private backing field and property validation
    private int marks;
    public int Marks
    {
        get { return marks; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("marks must be between 0 and 100");
            }
            marks = value;
        }
    }

    public string Grade { get; private set; }

    // constructor
    public Student1(int id, string name, int studentMarks)
    {
        StudentId = id;
        Name = name;
        Marks = studentMarks; // this triggers the setter validation
        Grade = CalculateGrade(Marks);
    }

    // method using a Func delegate inside to calculate grade
    private string CalculateGrade(int m)
    {
        Func<int, string> gradeFunc = score =>
        {
            if (score >= 90) return "A";
            if (score >= 75) return "B";
            if (score >= 60) return "C";
            return "D";
        };

        return gradeFunc(m);
    }
}

class Mains
{
    static void Main(string[] args)
    {
        try
        {
            // collection to store students
            List<Student1> students = new List<Student1>();

            // adding students
            students.Add(new Student1(1, "Rishabh", 88));
            students.Add(new Student1(2, "Aman", 94));
            students.Add(new Student1(3, "Priya", 65));
            students.Add(new Student1(4, "Neha", 45));

            Console.WriteLine("all student details and grades");
            foreach (var s in students)
            {
                Console.WriteLine($"id: {s.StudentId}, name: {s.Name}, marks: {s.Marks}, grade: {s.Grade}");
            }

            // using a predicate to filter students who passed with grade B or higher
            Predicate<Student1> highScorers = s => s.Marks >= 75;
            List<Student1> topStudents = students.FindAll(highScorers);

            Console.WriteLine("\nstudents with 75+ marks (filtered via predicate)");
            foreach (var s in topStudents)
            {
                Console.WriteLine($"{s.Name} scored {s.Marks} and got grade {s.Grade}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error caught: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}