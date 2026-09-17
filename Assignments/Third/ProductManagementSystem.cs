using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/*
 * Task: Product Management System
    Create a simple C# Console Application to manage products and categories.
    The application should allow you to:
    Add a product
    View all products
    Search products
    Update product price
    Delete a product
    View products by category


    Product should contain:
    ProductId
    ProductName
    Category
    Price


    Conditions:
    Product price cannot be negative.
    ProductId should be unique.
    ProductName cannot be empty.


    Technical Requirements:
    Try to implement the solution using the concepts we have covered:
    OOP concepts
    Classes, Objects, Constructors & Properties
    Inheritance, Polymorphism, Abstraction & Encapsulation
    Interfaces & Abstract Classes
    Collections & Generics
    Exception Handling
    Async/Await
    Delegates & Events
    Func, Action & Predicate
    Lambda Expressions
    LINQ (Where, Select, OrderBy, GroupBy, etc.)
    ADO.NET for storing and retrieving product data from SQL Server
    For LINQ, implement at least:
    Filtering products by price/category
    Selecting required product details
    Grouping products by category
    Joining products with categories


    No Entity Framework/Dapper. Use ADO.NET for database operations.
    Keep the application simple and focus on clean and understandable code.
    Thank you.
 * 
 * */

interface IProduct
{
    int AddProduct(int ProductId, string ProductName, string Category, decimal Price);
    List<string> ViewAllProducts();
    Dictionary<string, List<string>> SearchProduct(string searchTerm);
    bool UpdateProductPrice(int ProductId, decimal newPrice);
    bool DeleteProduct(int ProductId);
    string ViewProductsByCategory(string category);
}

//class Product : IProduct
//{

//}

class AssignmentThree {
    static void Main(string[] args)
    {
        Console.WriteLine("welcome\n");
        
        string ConnectionData = "Server=3.131.105.103;" +
            "Database=sDirectSDD2026;" +
            "User Id=sdirectsdd;" +
            "Password=sdirect2026;" +
            "TrustServerCertificate=True";

        using (SqlConnection connection = new SqlConnection(ConnectionData))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successfully established.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Connection error (Error #{ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
        }   
    }
}