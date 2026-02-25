// See https://aka.ms/new-console-template for more information
// Abstract class
abstract class Animal
{
    // Abstract method (does not have a body)
    public abstract void animalSound();
   
    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}

// Derived class (inherit from Animal)
class Pig : Animal
{
    public override void animalSound()
    {
        // The body of animalSound() is provided here
        Console.WriteLine("The pig says: wee wee");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pig myPig = new Pig();
        myPig.animalSound();  
        myPig.sleep();  
    }
}
