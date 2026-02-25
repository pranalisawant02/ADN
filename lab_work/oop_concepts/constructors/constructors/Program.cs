using System;

class Student
{
    int rollNo;
    string name;

    // 1️⃣ Default Constructor
    public Student()
    {
        rollNo = 0;
        name = "Not Assigned";
        Console.WriteLine("Default Constructor Called");
    }

    // 2️⃣ Parameterized Constructor
    public Student(int r, string n)
    {
        rollNo = r;
        name = n;
        Console.WriteLine("Parameterized Constructor Called");
    }

    // 3️⃣ Copy Constructor
    public Student(Student s)
    {
        rollNo = s.rollNo;
        name = s.name;
        Console.WriteLine("Copy Constructor Called");
    }

    // Method to display data
    public void Display()
    {
        Console.WriteLine($"Roll No: {rollNo}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Default Constructor
        Student s1 = new Student();
        s1.Display();

        // Parameterized Constructor
        Student s2 = new Student(101, "Rahul");
        s2.Display();

        // Copy Constructor
        Student s3 = new Student(s2);
        s3.Display();
    }
}
