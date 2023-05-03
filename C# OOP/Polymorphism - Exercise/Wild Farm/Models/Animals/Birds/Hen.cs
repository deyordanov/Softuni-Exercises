
namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Birds;
    using Foods;

    public class Hen : Bird
    {
        private const double weigtMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };


        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "Cluck";
    }
}
