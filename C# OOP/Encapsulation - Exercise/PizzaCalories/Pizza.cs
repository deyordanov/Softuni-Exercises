using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PizzaCalories.Items;
namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int ToppingsCount
        {
            get
            {
                if(this.toppings.Count() > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                return this.toppings.Count();
            }
        }

        public double TotalCalories => CalculateCalories();
        private double CalculateCalories()
        {
            double toppingsCal = 0;
            for(int i = 0; i < ToppingsCount; i++)
            {
                toppingsCal += toppings[i].CaloriesPerGram;
            }
            return dough.CaloriesPerGram + toppingsCal;
        }

        public void AddToppings(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }
    }
}
