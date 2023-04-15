using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double cals) : base(name, price, grams)
        {
            this.Calories = cals;
        }
        public double Calories { get; private set; }
    }
}
