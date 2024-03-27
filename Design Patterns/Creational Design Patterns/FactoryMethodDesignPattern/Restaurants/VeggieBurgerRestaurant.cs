namespace FactoryMethodDesignPattern.Restaurants;

using Burgers;
using Contracts;

public class VeggieBurgerRestaurant : AbstractRestaurant
{
    public override IBurger CreateBurger()
        => new VeggieBurger();
}