namespace AbstractFactoryDesignPattern.Factories;

using Contracts;
using Products;
using Products.Contracts;

public class DellManufacturer : IManufacturer
{
    public IGpu CreateGpu()
        => new DellGpu();

    public IMonitor CreateMonitor()
        => new DellMonitor();
}