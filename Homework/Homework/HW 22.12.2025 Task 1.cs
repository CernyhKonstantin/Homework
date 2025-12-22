using System;
using System.Collections.Generic;

class Program
{
    delegate bool NumberFilter(int number);

    static void ProcessArray(int[] array, NumberFilter filter, string title)
    {
        Console.WriteLine(title + ":");
        foreach (int num in array)
        {
            if (filter(num))
                Console.Write(num + " ");
        }
        Console.WriteLine("\n");
    }

    static bool IsEven(int n) => n % 2 == 0;

    static bool IsOdd(int n) => n % 2 != 0;

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;
        return true;
    }

    static bool IsFibonacci(int n)
    {
        int a = 0, b = 1;
        while (a <= n)
        {
            if (a == n) return true;
            int temp = a + b;
            a = b;
            b = temp;
        }
        return false;
    }

    static void Main()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5, 7, 8, 13, 21, 22 };

        ProcessArray(numbers, IsEven, "Even numbers");
        ProcessArray(numbers, IsOdd, "Odd numbers");
        ProcessArray(numbers, IsPrime, "Prime numbers");
        ProcessArray(numbers, IsFibonacci, "Fibonacci numbers");
    }
}
