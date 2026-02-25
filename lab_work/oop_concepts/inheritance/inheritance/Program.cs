// See https://aka.ms/new-console-template for more information

using System;

// Base Class (Parent)
class Person
{
    public string name;

    public void DisplayName()
    {
        Console.WriteLine("Name: " + name);
    }
}

// Derived Class (Child)
class Student : Person
{
    public int rollNo;

    public void DisplayStudent()
    {
        Console.WriteLine("Roll No: " + rollNo);
    }
}

class Program
{
    static void Main()
    {
        // Creating object of derived class
        Student s1 = new Student();

        // Accessing base class member
        s1.name = "Rahul";

        // Accessing derived class member
        s1.rollNo = 101;

        // Calling methods
        s1.DisplayName();
        s1.DisplayStudent();
    }
}
