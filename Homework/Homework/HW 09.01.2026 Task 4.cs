using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Generic Product class
public class Product<T>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime DateAdded { get; set; }
    public T Type { get; set; }

    public Product(string name, decimal price, DateTime dateAdded, T type)
    {
        Name = name;
        Price = price;
        DateAdded = dateAdded;
        Type = type;
    }

    public void Display()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}, Date: {DateAdded.ToShortDateString()}, Type: {Type}");
    }
}

// Generic Category class with iterator
public class Category<T> : IEnumerable<Product<T>>
{
    private List<Product<T>> products = new List<Product<T>>();

    public void AddProduct(Product<T> product)
    {
        products.Add(product);
    }

    // Filter by price range
    public IEnumerable<Product<T>> FilterByPrice(decimal min, decimal max)
    {
        foreach (var product in products)
        {
            if (product.Price >= min && product.Price <= max)
            {
                yield return product;
            }
        }
    }

    // Filter by last month
    public IEnumerable<Product<T>> FilterByLastMonth()
    {
        DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

        foreach (var product in products)
        {
            if (product.DateAdded >= oneMonthAgo)
            {
                yield return product;
            }
        }
    }

    public IEnumerator<Product<T>> GetEnumerator()
    {
        return products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Category<string> electronics = new Category<string>();

        electronics.AddProduct(new Product<string>("Laptop", 1200, DateTime.Now.AddDays(-10), "Electronics"));
        electronics.AddProduct(new Product<string>("Phone", 800, DateTime.Now.AddMonths(-2), "Electronics"));
        electronics.AddProduct(new Product<string>("Tablet", 450, DateTime.Now.AddDays(-5), "Electronics"));

        Console.WriteLine("All products:");
        foreach (var product in electronics)
        {
            product.Display();
        }

        Console.WriteLine("\nProducts with price between 400 and 1000:");
        foreach (var product in electronics.FilterByPrice(400, 1000))
        {
            product.Display();
        }

        Console.WriteLine("\nProducts added in the last month:");
        foreach (var product in electronics.FilterByLastMonth())
        {
            product.Display();
        }
    }
}
