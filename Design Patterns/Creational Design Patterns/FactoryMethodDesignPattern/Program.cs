using FactoryMethodDesignPattern.Restaurants;

BeefBurgerRestaurant beefRestaurant = new BeefBurgerRestaurant();

VeggieBurgerRestaurant veggieRestaurant = new VeggieBurgerRestaurant();

beefRestaurant.OrderBurger();
veggieRestaurant.OrderBurger();