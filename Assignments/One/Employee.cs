using System;
using System.Collections.Generic;

class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    static void Main(string[] args)
    {
        List<Employee> emps = new List<Employee>
        {
            new Employee { EmployeeId = 101, Name = "Rahul", Department = "IT", Salary = 50000m },
            new Employee { EmployeeId = 102, Name = "Dipak", Department = "HR", Salary = 45000m }
        };

        Console.WriteLine("employee details list:");
        foreach (var e in emps)
        {
            Console.WriteLine($"id: {e.EmployeeId}, name: {e.Name}, dept: {e.Department}, salary: {e.Salary}");
        }
    }
}