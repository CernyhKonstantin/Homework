//Task 1 + Task 3 – Play (with Destructor + IDisposable)

using System;

namespace Lesson_11
{
    public class Play : IDisposable
    {
        public string Title { get; set; }
        public string AuthorFullName { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }

        private bool disposed = false;

        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            AuthorFullName = author;
            Genre = genre;
            ReleaseYear = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Play: {Title}");
            Console.WriteLine($"Author: {AuthorFullName}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Year: {ReleaseYear}");
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
                    Console.WriteLine($"Play '{Title}' disposed (Dispose called).");
                }
                disposed = true;
            }
        }

        // Destructor
        ~Play()
        {
            Console.WriteLine($"Play '{Title}' destroyed (Destructor called).");
        }
    }
}
