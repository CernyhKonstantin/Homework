using System;

namespace FileSystem
{
    internal class Magazine
    {
        private static int nextId = 1; // IDs start at 1

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }

        public Magazine()
        {
            Id = nextId++;
            Title = "default";
            Publisher = "default";
            ReleaseDate = DateTime.Now;
            PageCount = 0;
        }

        public Magazine(string title, string publisher, DateTime releaseDate, int pageCount)
        {
            Id = nextId++;
            Title = title;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Title: {Title}, Publisher: {Publisher}, ReleaseDate: {ReleaseDate:yyyy-MM-dd}, Pages: {PageCount}";
        }

        // Reset IDs for every program start
        public static void ResetNextId()
        {
            nextId = 1;
        }
    }
}
