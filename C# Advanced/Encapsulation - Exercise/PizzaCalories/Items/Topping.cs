using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Items
{
    public class Topping
    {
        private string type;
        private double grams;
        private const double baseCalories = 2;
        private Dictionary<string, double> items = new Dictionary<string, double>
        {
            { "Meat", 1.2 },
            { "Veggies", 0.8 },
            { "Cheese", 1.1 },
            { "Sauce", 0.9 }
        };

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        private string Type
        {
            get => this.type;
            set
            {
                if (!this.items.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        private double Grams
        {
            get => this.grams;
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }

        public double CaloriesPerGram => CalculateCalories();
        private double CalculateCalories()
        {
            double typeModifier = items.Where(x => x.Key == this.Type).First().Value;
            return this.Grams * typeModifier * baseCalories;
        }
    }
}
