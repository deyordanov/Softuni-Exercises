using DecoratorDesignPattern.Decorators;
using DecoratorDesignPattern.Decorators.Contracts;

ICoffee coffee = new SimpleCoffee();
Console.WriteLine($"Cost: {coffee.GetCost()}; Ingredients: {coffee.GetIngredients()}");

ICoffee milkCoffee = new MilkCoffeeDecorator(coffee);
Console.WriteLine($"Cost: {milkCoffee.GetCost()}; Ingredients: {milkCoffee.GetIngredients()}");

ICoffee whipCoffee = new WhipCoffeeDecorator(coffee);
Console.WriteLine($"Cost: {whipCoffee.GetCost()}; Ingredients: {whipCoffee.GetIngredients()}");

ICoffee vanillaCoffee = new VanillaCoffeeDecorator(coffee);
Console.WriteLine($"Cost: {vanillaCoffee.GetCost()}; Ingredients: {vanillaCoffee.GetIngredients()}");

ICoffee mix = 
    new VanillaCoffeeDecorator(
        new WhipCoffeeDecorator(
            new MilkCoffeeDecorator(
                new SimpleCoffee())));

Console.WriteLine($"Cost: {mix.GetCost()}; Ingredients: {mix.GetIngredients()}");
