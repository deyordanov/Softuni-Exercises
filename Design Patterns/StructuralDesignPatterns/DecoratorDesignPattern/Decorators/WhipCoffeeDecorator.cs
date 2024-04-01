namespace DecoratorDesignPattern.Decorators;

using Contracts;

public class WhipCoffeeDecorator : CoffeeDecorator
{
    public WhipCoffeeDecorator(ICoffee coffee) 
        : base(coffee) { }

    public override double GetCost()
        => base.GetCost() + 0.7;

    public override string GetIngredients()
        => base.GetIngredients() + ", Whip";
}