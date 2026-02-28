/* It is a feature in C# and NET Framework that allows you to query:

Collections (List, Array)

Objects

Databases

XML

APIs

👉 Just like SQL, but inside C#.

✅ Why LINQ is Used?

Without LINQ:

More loops

More if conditions

More code

With LINQ:

Short

Clean

Readable

Powerful */


// basic ex => filter numbers

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 25, 30, 45, 60 };

        var result = numbers.Where(n => n > 30);

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}
