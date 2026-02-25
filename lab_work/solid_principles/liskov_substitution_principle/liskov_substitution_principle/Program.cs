// See https://aka.ms/new-console-template for more information

using System;
//base class
class Bird
{
    public virtual void Move()
    {
        Console.WriteLine("Bird moves");
    }
}
//derived class
class Sparrow : Bird
{
    public override void Move()
    {
        Console.WriteLine("Sparrow flies");
    }
}

class Ostrich : Bird
{
    public override void Move()
    {
        Console.WriteLine("Ostrich walks");
    }
}

class Program
{
    static void Main()
    {//apply lsp
        Bird b1 = new Sparrow();
        Bird b2 = new Ostrich();

        b1.Move();
        b2.Move();
    }
}
