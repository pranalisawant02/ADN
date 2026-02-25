// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        try
        {
            int a = 10;
            int b = 0;

            int result = a / b;   // This will cause error
            Console.WriteLine(result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }

        
    }
}
