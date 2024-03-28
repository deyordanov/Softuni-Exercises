using FactoryMethodDesignPattern.Contracts;

namespace FactoryMethodDesignPattern.Burgers;

public class BeefBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Preparing beef burger....");
    }
}