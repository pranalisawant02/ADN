// sorting integer list using lambda expression

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 50, 10, 40, 20, 30 };

        // Ascending order
        numbers.Sort((a, b) => a.CompareTo(b));

        Console.WriteLine("Ascending Order:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // Descending order
        numbers.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine("\nDescending Order:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
