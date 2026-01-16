using System;
using System.Globalization;

namespace FileSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Reset IDs at program start
            Magazine.ResetNextId();

            string path = "magazines.json";
            MagazineCMS cms = new MagazineCMS(path);

            // Create magazines
            Magazine mag1 = new Magazine("Tech Today", "Global Media", DateTime.ParseExact("2026-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), 120);
            Magazine mag2 = new Magazine("Science Monthly", "EduPub", DateTime.ParseExact("2025-12-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 95);

            // Add magazines to file
            cms.AddMagazineToFile(mag1);
            cms.AddMagazineToFile(mag2);

            Console.WriteLine("====================");
            cms.ShowAllMagazines();

            Console.WriteLine("====================");
            // Serialize a magazine to JSON
            string jsonMag1 = cms.SerializeMagazine(mag1);
            Console.WriteLine("Serialized Magazine JSON:");
            Console.WriteLine(jsonMag1);

            Console.WriteLine("====================");
            // Deserialize magazine from JSON
            Magazine restoredMag = cms.DeserializeMagazine(jsonMag1);
            Console.WriteLine("Deserialized Magazine object:");
            Console.WriteLine(restoredMag);

            Console.ReadKey();
        }
    }
}
