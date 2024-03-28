namespace AbstractFactoryDesignPattern.Factories.Contracts;

using Products.Contracts;

public interface IManufacturer
{
    IGpu CreateGpu();
    IMonitor CreateMonitor();
}