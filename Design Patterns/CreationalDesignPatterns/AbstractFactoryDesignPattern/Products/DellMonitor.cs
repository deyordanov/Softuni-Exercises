namespace AbstractFactoryDesignPattern.Products;

using Contracts;

public class DellMonitor : IMonitor
{
    public void Assemble()
    {
        Console.WriteLine("Assembling Dell monitor...");
    }
}