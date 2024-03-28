namespace FactoryMethodDesignPattern.Restaurants;

using Burgers;
using Contracts;

public class BeefBurgerRestaurant : AbstractRestaurant
{
    public override IBurger CreateBurger()
        => new BeefBurger();
}