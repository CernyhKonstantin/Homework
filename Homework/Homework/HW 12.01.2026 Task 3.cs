using System;

namespace Task3_DisposeAndDestructor
{
    class Play : IDisposable
    {
        public string Title { get; set; }

        public Play(string title)
        {
            Title = title;
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose called for play: {Title}");
        }

        ~Play()
        {
            Console.WriteLine($"Destructor called for play: {Title}");
        }
    }

    class Shop
    {
        public string Name { get; set; }

        public Shop(string name)
        {
            Name = name;
        }

        ~Shop()
        {
            Console.WriteLine($"Destructor called for shop: {Name}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Play play = new Play("Macbeth");
            play.Dispose();

            Shop shop = new Shop("Clothing Store");

            play = null;
            shop = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("End of program.");
        }
    }
}
