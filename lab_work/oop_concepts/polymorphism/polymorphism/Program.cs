// See https://aka.ms/new-console-template for more information

using System;

// Compile-Time Polymorphism (Method Overloading) 
class Calculator
{
    // Same method name, different parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

// ----------- Run-Time Polymorphism (Method Overriding) -----------
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main()
    {
        // Compile-Time Polymorphism
        Calculator calc = new Calculator();
        Console.WriteLine("Compile-Time Polymorphism:");
        Console.WriteLine(calc.Add(5, 3));       
        Console.WriteLine(calc.Add(2.5, 3.5));    

        Console.WriteLine();

        // Run-Time Polymorphism
        Console.WriteLine("Run-Time Polymorphism:");
        Animal obj = new Dog();   // Base reference, child object
        obj.Sound();              // Calls overridden method
    }
}
