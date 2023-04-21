using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if(this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }
            products.Add(product);
            this.Money -= product.Cost;
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            return this.products.Count == 0 ? $"{this.Name} - Nothing bought" : $"{this.Name} - {string.Join(", ", this.products.Select(x => x.Name))}";
        }
    }
}
