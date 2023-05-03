namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Birds;
    using Foods;

    public class Owl : Bird
    {
        private const double weigtMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => weigtMultiplier;

        public override string MakeSound() => "Hoot Hoot";
    }
}
