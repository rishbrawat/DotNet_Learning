using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }


    public Product()  {
    }

    public Product(int id, string name, string category, decimal price)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
        Price = price;
    }
}

class AssignmentThree
{
    static string ConnectionData = "Server=3.131.105.103;" +
        "Database=sDirectSDD2026;" +
        "User Id=sdirectsdd;" +
        "Password=sdirect2026;" +
        "TrustServerCertificate=True";

    static void Main(string[] args)
    {
        CreateTableIfNotExist();

        bool ConnectionOn = true;
        while (ConnectionOn)
        {
            Console.WriteLine("Product Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Search Products");
            Console.WriteLine("4. Update Product Price");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. View Products By Category");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            int Choice = Convert.ToInt32(Console.ReadLine());

            if (Choice == 1)
            {
                AddProduct();
            }
            else if (Choice == 2)
            {
                ViewAllProducts();
            }
            else if (Choice == 3)
            {
                SearchProducts();
            }
            else if (Choice == 4)
            {
                UpdateProductPrice();
            }
            else if (Choice == 5)
            {
                DeleteProduct();
            }
            else if (Choice == 6)
            {
                ViewProductsByCategory();
            }
            else if (Choice == 7)
            {
                ConnectionOn = false;
            }
            else
            {
                Console.WriteLine("invalid choice!");
            }
        }   
    }

    static void CreateTableIfNotExist()
    {
        using (SqlConnection Conn = new SqlConnection(ConnectionData))

        try{
                Conn.Open();
                string Query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' AND xtype='U') " +
                               "CREATE TABLE Products (" +
                               "ProductId INT PRIMARY KEY, " +
                               "ProductName NVARCHAR(100) NOT NULL, " +
                               "Category NVARCHAR(100), " +
                               "Price DECIMAL(18,2));";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.ExecuteNonQuery();
                }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error setting up a table: " + Ex.Message);
        }
    }

    static void AddProduct()
    {
        try
        {
            Console.Write("Enter Product ID: ");
            int Id = int.Parse(Console.ReadLine());

            if (CheckIdExists(Id))
            {
                Console.WriteLine("Product id already exists");
                return;
            }

            Console.Write("Enter Product Name: ");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Product name cant be empty");
                return;
            }

            Console.Write("Enter Category: ");
            string Category = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal Price = decimal.Parse(Console.ReadLine());
            if (Price < 0)
            {
                Console.WriteLine("Price cannot be negative");
                return;
            }

            using (SqlConnection Conn = new SqlConnection(ConnectionData))
            {
                Conn.Open();
                string Query = "INSERT INTO Products (ProductId, ProductName, Category, Price) VALUES (@Id, @Name, @Category, @Price)";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@Id", Id);
                    Cmd.Parameters.AddWithValue("@Name", Name);
                    Cmd.Parameters.AddWithValue("@Category", Category);
                    Cmd.Parameters.AddWithValue("@Price", Price);
                    Cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Product added.");
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error adding product: " + Ex.Message);
        }
    }

    static bool CheckIdExists(int id)
    {
        using (SqlConnection Conn = new SqlConnection(ConnectionData))
        {
            Conn.Open();
            string Query = "SELECT COUNT(1) FROM Products WHERE ProductId = @Id";
            using (SqlCommand Cmd = new SqlCommand(Query, Conn))
            {
                Cmd.Parameters.AddWithValue("@Id", id);
                int Count = (int)Cmd.ExecuteScalar();
                return Count > 0;
            }
        }
    }

    static List<Product> GetAllProductsList()
    {
        List<Product> ProductList = new List<Product>();

        using (SqlConnection Conn = new SqlConnection(ConnectionData))
        {
            Conn.Open();
            string Query = "SELECT ProductId, ProductName, Category, Price FROM Products";
            using (SqlCommand Cmd = new SqlCommand(Query, Conn))
            {
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Product P = new Product();
                        P.ProductId = Convert.ToInt32(Reader["ProductId"]);
                        P.ProductName = Reader["ProductName"].ToString();
                        P.Category = Reader["Category"].ToString();
                        P.Price = Convert.ToDecimal(Reader["Price"]);
                        ProductList.Add(P);
                    }
                }
            }
        }

        return ProductList;
    }

    static void ViewAllProducts()
    {
        try
        {
            List<Product> Products = GetAllProductsList();
            if (Products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("\nID\tName\tCategory\tPrice");
            foreach (Product P in Products)
            {
                Console.WriteLine($"{P.ProductId}\t{P.ProductName}\t{P.Category}\t{P.Price}");
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }

    static void SearchProducts()
    {
        try
        {
            Console.Write("Enter search name: ");
            string Name = Console.ReadLine();

            using (SqlConnection Conn = new SqlConnection(ConnectionData))
            {
                Conn.Open();
                string Query = "SELECT ProductId, ProductName, Category, Price FROM Products WHERE ProductName LIKE @Name";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nID\tName\tCategory\tPrice");
                        bool Found = false;
                        while (Reader.Read())
                        {
                            Found = true;
                            Console.WriteLine($"{Reader["ProductId"]}\t{Reader["ProductName"]}\t{Reader["Category"]}\t{Reader["Price"]}");
                        }

                        if (!Found)
                        {
                            Console.WriteLine("No match.");
                        }
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }

    static void UpdateProductPrice()
    {
        try
        {
            Console.Write("Enter Product ID to update: ");
            int Id = int.Parse(Console.ReadLine());

            if (!CheckIdExists(Id))
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new price: ");
            decimal NewPrice = decimal.Parse(Console.ReadLine());
            if (NewPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            using (SqlConnection Conn = new SqlConnection(ConnectionData))
            {
                Conn.Open();
                string Query = "UPDATE Products SET Price = @Price WHERE ProductId = @Id";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@Price", NewPrice);
                    Cmd.Parameters.AddWithValue("@Id", Id);
                    Cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Price updated.");
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error updating: " + Ex.Message);
        }
    }

    static void DeleteProduct()
    {
        try
        {
            Console.Write("Enter Product ID to delete: ");
            int Id = int.Parse(Console.ReadLine());

            using (SqlConnection Conn = new SqlConnection(ConnectionData))
            {
                Conn.Open();
                string Query = "DELETE FROM Products WHERE ProductId = @Id";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@Id", Id);
                    int Rows = Cmd.ExecuteNonQuery();
                    if (Rows > 0)
                    {
                        Console.WriteLine("Product deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error deleting: " + Ex.Message);
        }
    }

    static void ViewProductsByCategory()
    {
        try
        {
            Console.Write("Enter category name: ");
            string CategoryName = Console.ReadLine();

            using (SqlConnection Conn = new SqlConnection(ConnectionData))
            {
                Conn.Open();
                string Query = "SELECT ProductId, ProductName, Category, Price FROM Products WHERE Category = @Category";
                using (SqlCommand Cmd = new SqlCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@Category", CategoryName);
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nID\tName\tCategory\tPrice");
                        bool Found = false;
                        while (Reader.Read())
                        {
                            Found = true;
                            Console.WriteLine($"{Reader["ProductId"]}\t{Reader["ProductName"]}\t{Reader["Category"]}\t{Reader["Price"]}");
                        }

                        if (!Found)
                        {
                            Console.WriteLine("No products found in this category.");
                        }
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}