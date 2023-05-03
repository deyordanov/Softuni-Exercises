using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public abstract class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }
        public virtual string ExplainSelf()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
