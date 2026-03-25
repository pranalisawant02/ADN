using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SYNCHRONOUS EXECUTION ===");
        SynchronousMethod();

        Console.WriteLine("\n=== ASYNCHRONOUS EXECUTION ===");
        // Calling async method from Main (wait using .GetAwaiter().GetResult())
        AsynchronousMethod().GetAwaiter().GetResult();

        Console.WriteLine("\n=== METHOD RETURNING TASK ===");
        TaskReturningMethod().GetAwaiter().GetResult();

        Console.WriteLine("\nProgram Finished");
    }

    // ---------------- TASK 1 ----------------
    // Synchronous method (blocking execution using Thread.Sleep)
    static void SynchronousMethod()
    {
        Console.WriteLine("Start Sync Task...");

        Thread.Sleep(3000); // Blocks the thread for 3 seconds

        Console.WriteLine("End Sync Task");
    }

    // ---------------- TASK 2 & 3 ----------------
    // Asynchronous method using async & await + Task.Delay
    static async Task AsynchronousMethod()
    {
        Console.WriteLine("Start Async Task...");

        await Task.Delay(3000); // Non-blocking delay (does NOT block thread)

        Console.WriteLine("End Async Task");
    }

    // ---------------- TASK 4 ----------------
    // Method returning Task
    static async Task TaskReturningMethod()
    {
        Console.WriteLine("Task method started...");

        await PerformWork(); // Calling another async method

        Console.WriteLine("Task method completed...");
    }

    // Separate method returning Task
    static async Task PerformWork()
    {
        Console.WriteLine("Performing work...");

        await Task.Delay(2000); // Simulates async work

        Console.WriteLine("Work done!");
    }
}