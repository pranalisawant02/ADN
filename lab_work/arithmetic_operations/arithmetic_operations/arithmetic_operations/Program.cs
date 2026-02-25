// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        // Declare variables
        double num1, num2;

        // Take input from user
        Console.Write("Enter first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        // Perform arithmetic operations
        double addition = num1 + num2;
        double subtraction = num1 - num2;
        double multiplication = num1 * num2;
        double division = num1 / num2;

        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("Addition: " + addition);
        Console.WriteLine("Subtraction: " + subtraction);
        Console.WriteLine("Multiplication: " + multiplication);
        Console.WriteLine("Division: " + division);
    }
}

