using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double weigtMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "Squeak";
    }
}
