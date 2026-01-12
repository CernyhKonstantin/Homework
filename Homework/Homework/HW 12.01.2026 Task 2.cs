using System;

namespace Task2_Shop
{
    enum ShopType
    {
        Grocery,
        Household,
        Clothing,
        Shoes
    }

    class Shop : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }

        public Shop(string name, string address, ShopType type)
        {
            Name = name;
            Address = address;
            Type = type;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Shop name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Type: {Type}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose called for shop: {Name}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Shop shop = new Shop("Food Market", "Central Street 5", ShopType.Grocery);
            shop.DisplayInfo();

            shop.Dispose();

            Console.WriteLine("End of program.");
        }
    }
}
