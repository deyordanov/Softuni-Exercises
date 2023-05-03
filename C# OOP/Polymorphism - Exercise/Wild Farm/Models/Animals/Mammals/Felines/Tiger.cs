
namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;
    public class Tiger : Feline
    {
        private const double weigtMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "ROAR!!!";
    }
}
