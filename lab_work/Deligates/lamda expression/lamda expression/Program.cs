/* Lambda expression is an anonymous method used to simplify delegate implementation.
In multicast delegate, multiple lambda expressions can be added using += and all will execute when the delegate is invoked.
*/
using System;

class NotificationSystem
{
    // Step 1: Declare delegate
    public delegate void Notify(string message);

    static void Main()
    {
        Console.Write("Enter Message to Send: ");
        string message = Console.ReadLine();

        // Step 2: Create delegate instance
        Notify notifyUser = null;

        // Step 3: Add Lambda Expressions (instead of methods)

        notifyUser += (msg) =>
        {
            Console.WriteLine("Email Notification: " + msg);
        };

        notifyUser += (msg) =>
        {
            Console.WriteLine("SMS Notification: " + msg);
        };

        notifyUser += (msg) =>
        {
            Console.WriteLine("Push Notification: " + msg);
        };

        // Step 4: Invoke delegate
        Console.WriteLine("\nSending Notifications...\n");
        notifyUser(message);
    }
}
