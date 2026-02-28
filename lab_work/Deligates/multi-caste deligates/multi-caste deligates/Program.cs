//A multicast delegate is a delegate that can hold multiple method references and call them one after another.



using System;

class NotificationSystem
{
    // Step 1: Declare delegate
    public delegate void Notify(string message);

    // Step 2: Define notification methods
    public static void SendEmail(string msg)
    {
        Console.WriteLine("Email Notification: " + msg);
    }

    public static void SendSMS(string msg)
    {
        Console.WriteLine("SMS Notification: " + msg);
    }

    public static void SendPushNotification(string msg)
    {
        Console.WriteLine("Push Notification: " + msg);
    }

    static void Main()
    {
        Console.Write("Enter Message to Send: ");
        string message = Console.ReadLine();

        // Step 3: Create delegate instance
        Notify notifyUser = null;

        // Step 4: Add multiple methods (Multicasting)
        notifyUser += SendEmail;
        notifyUser += SendSMS;
        notifyUser += SendPushNotification;

        // Step 5: Trigger notifications
        Console.WriteLine("\nSending Notifications...\n");
        notifyUser(message);
    }
}


/*
  Notify delegate holds multiple methods

When notifyUser(message) is called
👉 All attached methods execute one by one


Multicast delegate is possible only with void return type (commonly used).

Methods are executed in the order they are added.

Use += to add methods.

Use -= to remove methods.

If one method throws an exception, remaining methods will NOT execute. */
