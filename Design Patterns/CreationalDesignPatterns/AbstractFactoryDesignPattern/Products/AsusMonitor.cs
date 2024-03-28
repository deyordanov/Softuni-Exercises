namespace AbstractFactoryDesignPattern.Products;

using Contracts;

public class AsusMonitor : IMonitor
{
    public void Assemble()
    {
        Console.WriteLine("Assembling ASUS monitor...");
    }
}