//Task 2 + Task 3 – Shop (with IDisposable + Destructor)

using System;

namespace Lesson_11
{
    public enum ShopType
    {
        Grocery,
        Household,
        Clothing,
        Shoes
    }

    public class Shop : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }

        private bool disposed = false;

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

        // IDisposable implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Shop '{Name}' disposed (Dispose called).");
                }
                disposed = true;
            }
        }

        // Destructor (added in Task 3)
        ~Shop()
        {
            Console.WriteLine($"Shop '{Name}' destroyed (Destructor called).");
        }
    }
}
