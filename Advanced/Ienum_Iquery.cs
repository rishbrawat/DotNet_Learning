using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableVsIQueryable
{
    // ienumerable is for in-memory collections like lists, arrays, or dictionaries.
    // when u query an ienumerable, all the data is already loaded into ram, and the filtering 
    // happens locally on your client machine (client-side execution).
    
    // iqueryable inherits from ienumerable but its built for remote data sources like sql databases via entity framework.
    // instead of pulling every single row into memory, it uses expression trees to translate your c# code 
    // into a sql query so the database server does the heavy lifting (server-side execution).

    class Program
    {
        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        static void Main(string[] args)
        {
            
            // create some dummy products in memory
            List<Product> localProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200m },
                new Product { Id = 2, Name = "Mouse", Price = 25m },
                new Product { Id = 3, Name = "Keyboard", Price = 75m },
                new Product { Id = 4, Name = "Monitor", Price = 300m }
            };

            // ienumerable uses standard Func delegates under the hood.
            // everything here runs completely in local memory.
            IEnumerable<Product> cheapItemsEnum = localProducts.Where(p => p.Price < 100);

            Console.WriteLine("filtering local list using ienumerable:");
            foreach (var item in cheapItemsEnum)
            {
                Console.WriteLine($"  found: {item.Name} at ${item.Price}");
            }


            Console.WriteLine("\niqueryable demo");
            
            // even though our list is local, we can turn it into an iqueryable using AsQueryable().
            // in a real web app, this would typically come from your database context like: db.Products
            IQueryable<Product> queryableProducts = localProducts.AsQueryable().Where(p => p.Price < 100);

            // instead of running immediately, iqueryable builds an "Expression Tree" (it stores the query logic as data).
            // u can actually print the expression tree to see how it looks:
            Console.WriteLine("expression tree representation:");
            Console.WriteLine(queryableProducts.Expression);

            Console.WriteLine("\nexecuting queryable loop:");
            // execution only happens when we actually loop through it or call something like .ToList()
            foreach (var item in queryableProducts)
            {
                Console.WriteLine($"  found from queryable: {item.Name} at ${item.Price}");
            }

        }
    }
}