// iqueryable is used for the data, that comes through a database
// IQueryable<T> : build a query that can be executed on the data source itself

using System;
using System.Linq;
using System.Collections.Generic;

class IQr
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> {1,2,3,4,5,6,7,8,9,10};

        IQueryable<int> query = numbers.AsQueryable();

        IQueryable<int> evenNumbers = query.Where(a => a % 2 == 0);

        foreach(int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
