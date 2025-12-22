using System;

class Program
{
    delegate int StringOperation(string text);

    static int CountVowels(string text)
    {
        int count = 0;
        string vowels = "aeiouAEIOU";

        foreach (char c in text)
            if (vowels.Contains(c))
                count++;

        return count;
    }

    static int CountConsonants(string text)
    {
        int count = 0;

        foreach (char c in text)
            if (char.IsLetter(c) && !"aeiouAEIOU".Contains(c))
                count++;

        return count;
    }

    static int GetLength(string text)
    {
        return text.Length;
    }

    static void Execute(string text, StringOperation operation, string description)
    {
        Console.WriteLine(description + ": " + operation(text));
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Execute(input, CountVowels, "Number of vowels");
        Execute(input, CountConsonants, "Number of consonants");
        Execute(input, GetLength, "String length");
    }
}
