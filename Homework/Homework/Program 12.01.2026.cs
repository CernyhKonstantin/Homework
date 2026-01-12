//Program.cs(Testing ALL tasks)

using System;

namespace Lesson_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TASK 1 & 3: Play ===");

            Play play = new Play(
                "Hamlet",
                "William Shakespeare",
                "Tragedy",
                1603
            );

            play.DisplayInfo();

            play.Dispose();
            play = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\n=== TASK 2 & 3: Shop ===");

            Shop shop = new Shop(
                "Fashion Store",
                "Main Street 12",
                ShopType.Clothing
            );

            shop.DisplayInfo();

            shop.Dispose();
            shop = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\nProgram finished.");
        }
    }
}
