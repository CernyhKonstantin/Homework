using System;

namespace Task1_Play
{
    class Play
    {
        public string Title { get; set; }
        public string AuthorFullName { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }

        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            AuthorFullName = author;
            Genre = genre;
            ReleaseYear = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {AuthorFullName}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Year: {ReleaseYear}");
        }

        // Destructor
        ~Play()
        {
            Console.WriteLine($"Destructor called for play: {Title}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Play play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1603);
            play.DisplayInfo();

            play = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("End of program.");
        }
    }
}
