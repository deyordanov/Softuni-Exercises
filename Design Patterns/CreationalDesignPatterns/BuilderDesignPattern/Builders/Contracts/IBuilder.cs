namespace BuilderDesignPattern.Builders.Contracts;

public interface IBuilder
{
    IBuilder Id(int id);
    IBuilder Brand(string brand);
    IBuilder Model(string model);
    IBuilder Color(string color);
    IBuilder Engine(string engine);
    IBuilder Horsepower(string horsepower);
}