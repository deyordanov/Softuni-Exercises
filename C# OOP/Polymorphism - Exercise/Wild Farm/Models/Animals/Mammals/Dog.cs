
namespace WildFarm.Models.Animals.Mammals
{
    using Foods;
    public class Dog : Mammal
    {
        private const double weigtMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "Woof!";

    }
}
