
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            string ability =
                this.GetType().Name == "Druid" || this.GetType().Name == "Paladin" ? "healed" : "hit";

            string typeOfAttack = 
                this.GetType().Name == "Druid" || this.GetType().Name == "Paladin" ? $"{this.Power}" : $"{this.Power} damage";

            return string.Format(this.ToString(), this.GetType().Name, this.Name, ability, typeOfAttack);
        }

        public override string ToString()
        {
            return "{0} - {1} {2} for {3}";
        }
    }
}
