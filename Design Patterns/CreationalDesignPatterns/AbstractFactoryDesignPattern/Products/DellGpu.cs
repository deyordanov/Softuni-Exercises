namespace AbstractFactoryDesignPattern.Products;

using Contracts;

public class DellGpu : IGpu
{
    public void Assemble()
    {
        Console.WriteLine("Assembling Dell gpu...");
    }
}