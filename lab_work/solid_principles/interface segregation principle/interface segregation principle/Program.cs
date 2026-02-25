// See https://aka.ms/new-console-template for more information


// Separate small interfaces
interface IWork
{
    void Work();
}

interface IEat
{
    void Eat();
}

// Human can work and eat
class Human : IWork, IEat
{
    public void Work()
    {
        Console.WriteLine("Human working");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating");
    }
}

// Robot only works
class Robot : IWork
{
    public void Work()
    {
        Console.WriteLine("Robot working");
    }
}

class Program
{
    static void Main()
    {
        IWork human = new Human();
        human.Work();

        IWork robot = new Robot();
        robot.Work();
    }
}
