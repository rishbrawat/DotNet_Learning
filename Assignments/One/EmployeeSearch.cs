using System;
using System.Collections.Generic;

class EmployeeSearch
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
        Dictionary<int, EmpRecord> empDict = new Dictionary<int, EmpRecord>();

        empDict.Add(101, new EmpRecord { EmployeeId = 101, Name = "Rohan", Department = "IT", Salary = 60000m });
        empDict.Add(102, new EmpRecord { EmployeeId = 102, Name = "Sneha", Department = "HR", Salary = 48000m });

        Console.WriteLine("enter employee id to search: ");
        int searchId = Convert.ToInt32(Console.ReadLine());

        if (empDict.ContainsKey(searchId))
        {
            EmpRecord e = empDict[searchId];
            Console.WriteLine("employee found: ");
            Console.WriteLine($"id: {e.EmployeeId}, name: {e.Name}, dept: {e.Department}, salary: {e.Salary}");
        }
        else
        {
            Console.WriteLine("employee with this id does not exist");
        }
    }
}