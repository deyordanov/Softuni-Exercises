
namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;
    public class Cat : Feline
    {
        private const double weigtMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "Meow";
    }
}
