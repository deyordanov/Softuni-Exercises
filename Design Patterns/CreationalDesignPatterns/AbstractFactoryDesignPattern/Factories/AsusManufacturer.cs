namespace AbstractFactoryDesignPattern.Factories;

using Contracts;
using Products;
using Products.Contracts;

public class AsusManufacturer : IManufacturer
{
    public IGpu CreateGpu()
        => new AsusGpu();

    public IMonitor CreateMonitor()
        => new AsusMonitor();
}