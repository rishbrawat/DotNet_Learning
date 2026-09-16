using System;
using System.Collections.Generic;

class EmployeeList
{
    class EmpRecord
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    static void Main(string[] args)
    {
        List<EmpRecord> employees = new List<EmpRecord>
        {
            new EmpRecord { EmployeeId = 1, Name = "Rishabh", Department = "IT", Salary = 400000m },
            new EmpRecord { EmployeeId = 2, Name = "Ankush", Department = "Finance", Salary = 55000m },
            new EmpRecord { EmployeeId = 3, Name = "Chandu", Department = "Sales", Salary = 35000m }
        };

        Console.WriteLine("listing all employees using loop:");
        foreach (var emp in employees)
        {
            Console.WriteLine($"id: {emp.EmployeeId}, name: {emp.Name}, department: {emp.Department}, salary: {emp.Salary}");
        }
    }
}