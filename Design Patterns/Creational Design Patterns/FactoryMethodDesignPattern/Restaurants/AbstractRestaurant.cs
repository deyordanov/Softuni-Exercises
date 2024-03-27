namespace FactoryMethodDesignPattern.Restaurants;

using Contracts;

public abstract class AbstractRestaurant
{

    public void OrderBurger()
    {
        Console.WriteLine("Ordering burger...");
        IBurger burger = CreateBurger();
        burger.Prepare();
    }
    public abstract IBurger CreateBurger();
}