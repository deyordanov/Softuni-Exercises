namespace AbstractFactoryDesignPattern.Products;

using Contracts;

public class AsusGpu : IGpu
{
    public void Assemble()
    {
        Console.WriteLine("Assembling ASUS gpu...");
    }
}