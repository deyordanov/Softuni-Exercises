namespace BuilderDesignPattern;

using Builders.Contracts;

public class Director
{
    public void BuildBmw(IBuilder builder)
    {
        builder
            .Id(1)
            .Brand("BMW")
            .Model("550d")
            .Color("Blue")
            .Engine("5L")
            .Horsepower("381");
    }

    public void BuildMercedes(IBuilder builder)
    {
        builder
            .Id(2)
            .Brand("Mercedes")
            .Model("C63 AMG");
    }
}