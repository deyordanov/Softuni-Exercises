using FactoryMethodDesignPattern.Contracts;

namespace FactoryMethodDesignPattern.Burgers;

public class VeggieBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Preparing veggie burger....");
    }
}