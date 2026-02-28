//Calculator using delegates

//delegate is a type that represents references to methods with a particular parameter list and return type.
//When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type.
//You can invoke the method through the delegate instance.

using System;

class Calculator
{
    // Step 1: Declare Delegate
    public delegate double Operation(double a, double b);

    // Step 2: Define Methods
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero!");
            return 0;
        }
        return a / b;
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nChoose Operation:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");

        Console.Write("Enter choice (1-4): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Operation op = null;

        switch (choice)
        {
            case 1:
                op = Add;
                break;
            case 2:
                op = Subtract;
                break;
            case 3:
                op = Multiply;
                break;
            case 4:
                op = Divide;
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        double result = op(num1, num2);
        Console.WriteLine("Result = " + result);
    }
}