// See https://aka.ms/new-console-template for more information
using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Basic variables
            int myNum = 20;
            double myDoubleNum = 5.99D;
            char myLetter = 'D';
            bool myBool = true;
            string myText = "Hello";

            Console.WriteLine(myNum);
            Console.WriteLine(myDoubleNum);
            Console.WriteLine(myLetter);
            Console.WriteLine(myBool);
            Console.WriteLine(myText);

            // Constant
            const int myNumber = 15;
            Console.WriteLine(myNumber);

            // PASS / FAIL
            int marks;
            Console.Write("Enter marks: ");
            marks = Convert.ToInt32(Console.ReadLine());

            if (marks >= 40)
                Console.WriteLine("Pass");
            else
                Console.WriteLine("Fail");

            // ODD / EVEN
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");

            // LOOP (for)
            Console.WriteLine("For loop:");
            for (int i = 1; i <= 5; i++)
                Console.WriteLine(i);

            // LOOP (while)
            Console.WriteLine("While loop:");
            int j = 1;
            while (j <= 5)
            {
                Console.WriteLine(j);
                j++;
            }

            // FUNCTION CALL
            int sum = Add(10, 20);
            Console.WriteLine("Sum = " + sum);
        }

        // FUNCTION
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
