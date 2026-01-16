using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FileSystem
{
    internal class MagazineCMS
    {
        public string PathToFile { get; private set; }

        public MagazineCMS(string path)
        {
            PathToFile = path;
            // Clear file at program start
            File.WriteAllText(PathToFile, "[]");
        }

        // Add magazine and save to file
        public void AddMagazineToFile(Magazine mag)
        {
            string json = File.ReadAllText(PathToFile);
            List<Magazine> magazines = JsonConvert.DeserializeObject<List<Magazine>>(json) ?? new List<Magazine>();

            magazines.Add(mag);

            string updatedJson = JsonConvert.SerializeObject(magazines, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(PathToFile, updatedJson);

            Console.WriteLine($"Magazine '{mag.Title}' added successfully!");
        }

        // Show all magazines
        public void ShowAllMagazines()
        {
            string json = File.ReadAllText(PathToFile);
            List<Magazine> magazines = JsonConvert.DeserializeObject<List<Magazine>>(json) ?? new List<Magazine>();

            Console.WriteLine("All magazines in file:");
            foreach (var m in magazines)
            {
                Console.WriteLine(m.ToString());
            }
        }

        // Serialize magazine to JSON string
        public string SerializeMagazine(Magazine mag)
        {
            return JsonConvert.SerializeObject(mag, Newtonsoft.Json.Formatting.Indented);
        }

        // Deserialize JSON string to magazine
        public Magazine DeserializeMagazine(string json)
        {
            return JsonConvert.DeserializeObject<Magazine>(json) ?? new Magazine();
        }
    }
}
