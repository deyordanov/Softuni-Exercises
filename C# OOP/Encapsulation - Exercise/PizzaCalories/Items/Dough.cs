using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Items
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private const double baseCalories = 2;
        private Dictionary<string, double> items = new Dictionary<string, double>
        {
            { "White", 1.5 },
            { "Wholegrain", 1.0 },
            { "Crispy", 0.9 },
            { "Chewy", 1.1 },
            { "Homemade", 1.0 }

        };
        public Dough(string type, string technique, double grams)
        {
            this.FlourType = type;
            this.BakingTechnique = technique;
            this.Grams = grams;
        }
        private string FlourType
        {
            get => this.flourType;
            set
            {
                if(!this.items.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (!this.items.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private double Grams
        {
            get => this.grams;
            set
            {
                if (value< 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.grams = value;
            }
        }
        public double CaloriesPerGram => CalculateCalories();
        private double CalculateCalories()
        {
            double typeModifier = items.Where(x => x.Key == this.FlourType).First().Value;
            double techniqueModifier = items.Where(x => x.Key == this.BakingTechnique).First().Value;
            return (this.Grams * baseCalories) * typeModifier * techniqueModifier;
        }
    }
}
