using System;
using System.IO;
using Microsoft.Extensions.Logging;
using FileSystem;

namespace FileSystem;

internal class Program
{
    private static readonly string LogFilePath =
        "C:" + Path.DirectorySeparatorChar + Path.Combine("test", "app.log");

    static void Main(string[] args)
    {
        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath)!);

        // Create LoggerFactory
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();

        logger.LogInformation("Application started");

        // Create person
        Person person = new Person
        {
            Name = "Bob",
            Age = 20
        };

        logger.LogInformation("Person object created: {Person}", person.ToString());

        // Write person data to file
        WriteToFile(LogFilePath, person.ToString(), logger);

        // Read data from file
        string fileData = ReadFromFile(LogFilePath, logger);

        Console.WriteLine("Data read from file:");
        Console.WriteLine(fileData);

        logger.LogInformation("Application finished");
    }

    static void WriteToFile(string path, string message, ILogger logger)
    {
        using StreamWriter sw = new StreamWriter(path, true);
        sw.WriteLine(message);

        logger.LogInformation("Message written to file: {Message}", message);
    }

    static string ReadFromFile(string path, ILogger logger)
    {
        using StreamReader sr = new StreamReader(path);
        string content = sr.ReadToEnd();

        logger.LogInformation("File read successfully");

        return content;
    }
}
