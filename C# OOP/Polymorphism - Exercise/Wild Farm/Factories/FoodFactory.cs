
namespace WildFarm.Factories
{
    using Interfaces;
    using Exceptions;
    using Models.Foods;
    using Models.Interfaces;

    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            if(type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if(type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if(type == "Meat")
            {
                return new Meat(quantity);
            }
            else if(type == "Seeds")
            {
                return new Seeds(quantity);
            }
            else
            {
                throw new InvalidFoodTypeException();
            }
        }
    }
}
