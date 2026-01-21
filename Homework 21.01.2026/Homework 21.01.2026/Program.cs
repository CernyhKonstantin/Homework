using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Phones
{
    class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Phone(string name, string manufacturer, double price, DateTime releaseDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"{Name} | Manufacturer: {Manufacturer} | Price: {Price:C} | Release Date: {ReleaseDate:yyyy-MM-dd}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone("Galaxy S21", "Samsung", 799, new DateTime(2021, 1, 29)),
                new Phone("iPhone 12", "Apple", 999, new DateTime(2020, 10, 23)),
                new Phone("Pixel 5", "Google", 699, new DateTime(2020, 10, 15)),
                new Phone("Moto G Power", "Motorola", 249, new DateTime(2021, 3, 18)),
                new Phone("OnePlus 9", "OnePlus", 729, new DateTime(2021, 3, 23)),
                new Phone("Nokia 3310", "Nokia", 59, new DateTime(2000, 9, 1))
            };

            int totalPhones = phones.Count();
            Console.WriteLine($"1) Total number of phones: {totalPhones}");

            int priceOver100 = phones.Count(p => p.Price > 100);
            Console.WriteLine($"2) Phones with price > 100: {priceOver100}");

            int priceBetween400And700 = phones.Count(p => p.Price >= 400 && p.Price <= 700);
            Console.WriteLine($"3) Phones with price between 400 and 700: {priceBetween400And700}");

            string targetManufacturer = "Samsung";
            int countManufacturer = phones.Count(p => p.Manufacturer == targetManufacturer);
            Console.WriteLine($"4) Number of phones from {targetManufacturer}: {countManufacturer}");

            Phone minPricePhone = phones.OrderBy(p => p.Price).First();
            Console.WriteLine($"\n5) Phone with minimum price: {minPricePhone}");

            Phone maxPricePhone = phones.OrderByDescending(p => p.Price).First();
            Console.WriteLine($"\n6) Phone with maximum price: {maxPricePhone}");

            Phone oldestPhone = phones.OrderBy(p => p.ReleaseDate).First();
            Console.WriteLine($"\n7) Oldest phone: {oldestPhone}");

            Phone newestPhone = phones.OrderByDescending(p => p.ReleaseDate).First();
            Console.WriteLine($"\n8) Newest phone: {newestPhone}");

            double avgPrice = phones.Average(p => p.Price);
            Console.WriteLine($"\n9) Average phone price: {avgPrice:C}");
        }
    }
}
