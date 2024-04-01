namespace DecoratorDesignPattern.Decorators;

using Contracts;

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        this._coffee = coffee;
    }

    public virtual double GetCost()
        => this._coffee.GetCost();

    public virtual string GetIngredients()
        => this._coffee.GetIngredients();
}