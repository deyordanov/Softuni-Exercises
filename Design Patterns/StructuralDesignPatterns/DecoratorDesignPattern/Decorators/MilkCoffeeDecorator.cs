namespace DecoratorDesignPattern.Decorators;

using Contracts;

public class MilkCoffeeDecorator : CoffeeDecorator
{
    public MilkCoffeeDecorator(ICoffee coffee) 
        : base(coffee) { }

    public override double GetCost()
        => base.GetCost() + 0.5;

    public override string GetIngredients()
        => base.GetIngredients() + ", Milk";
}