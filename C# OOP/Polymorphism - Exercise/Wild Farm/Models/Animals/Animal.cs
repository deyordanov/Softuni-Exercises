namespace WildFarm.Models.Animals
{
    using WildFarm.Exceptions;
    using WildFarm.Models.Interfaces;
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFood { get; }

        public void Eat(IFood food)
        {
            if(!this.PreferredFood.Any(f => f.Name == food.GetType().Name))
            {
                throw new CannotEatFoodException(string.Format(ExceptionMessages.CannotEatFoodMessage, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public abstract string MakeSound();
    }
}
