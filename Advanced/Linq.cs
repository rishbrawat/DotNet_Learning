using System;
using System.Collections.Generic;
using System.Linq;

// linq allows us to query, filter and manipulate the data from different resoucrces
// linq = language integrated query

namespace LinqOperators
{
    // simple models for our data
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int DeptId { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // setup some dummy data to work with
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "HR" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "Sales" }
            };

            var employees = new List<Employee>
            {
                new Employee { Name = "Alice", DeptId = 2, Age = 28 },
                new Employee { Name = "Bob", DeptId = 1, Age = 35 },
                new Employee { Name = "Charlie", DeptId = 2, Age = 24 },
                new Employee { Name = "Diana", DeptId = 3, Age = 30 },
                new Employee { Name = "Evan", DeptId = 1, Age = 41 }
            };

            // filtering operator(Where)

            // filtering is used to pick items that match a specific condition.
            // basicly like a sql WHERE clause.
            Console.WriteLine("filtering (Employees older than 28)");
            
            var olderEmployees = employees.Where(e => e.Age > 28).ToList();

            foreach (var emp in olderEmployees)
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}");
            }


            // projection operator (Select)
    
            // projection transforms data from one shape/type into another. 
            // u use Select when u only want specific properties or want to shape a new object.
            Console.WriteLine("\nprojection (Just employee names in uppercase)");
            
            var employeeNames = employees.Select(e => e.Name.ToUpper()).ToList();

            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }


            // grouping operator
            // grouping takes a flat list and splits it into buckets based on a key selector.
            Console.WriteLine("\ngrouping (Employees grouped by DeptId)");
            
            var groupedEmployees = employees.GroupBy(e => e.DeptId);

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"Department ID: {group.Key}");
                foreach (var emp in group)
                {
                    Console.WriteLine($"   - {emp.Name}");
                }
            }


            // join operatora
            // joins combine two data sources based on a matching key (like an inner join in sql).
            Console.WriteLine("\n joins (Matching employees with their departments)");
            
            var employeeDetails = employees.Join(
                departments,
                emp => emp.DeptId,         // outer key selector
                dept => dept.Id,           // inner key selector
                (emp, dept) => new         // result selector (what to output)
                {
                    EmployeeName = emp.Name,
                    DepartmentName = dept.Name
                }
            );

            foreach (var detail in employeeDetails)
            {
                Console.WriteLine($"{detail.EmployeeName} works in {detail.DepartmentName}");
            }

        }
    }
}