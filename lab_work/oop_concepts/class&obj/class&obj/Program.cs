
// Define a class
class Student
{
    // Fields (data members)
    public int rollNo;
    public string name;

    // Method (member function)
    public void Display()
    {
        Console.WriteLine("Roll No: " + rollNo);
        Console.WriteLine("Name: " + name);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an object of Student class
        Student s1 = new Student();

        // Assigning values 
        s1.rollNo = 101;
        s1.name = "Rahul";

        //method calling
        s1.Display();
    }
}
