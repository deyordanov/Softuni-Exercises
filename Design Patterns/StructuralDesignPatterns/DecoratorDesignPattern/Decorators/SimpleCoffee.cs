namespace DecoratorDesignPattern.Decorators;

using Contracts;

public class SimpleCoffee : ICoffee
{
    public double GetCost()
        => 1;

    public string GetIngredients()
        => "Coffee";
}