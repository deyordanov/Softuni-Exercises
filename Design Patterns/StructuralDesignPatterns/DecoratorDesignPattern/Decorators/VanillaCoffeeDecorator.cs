namespace DecoratorDesignPattern.Decorators;

using Contracts;

public class VanillaCoffeeDecorator : CoffeeDecorator
{
    public VanillaCoffeeDecorator(ICoffee coffee) 
        : base(coffee) { }

    public override double GetCost()
        => base.GetCost() + 1.0;

    public override string GetIngredients()
        => base.GetIngredients() + ", Vanilla";
}