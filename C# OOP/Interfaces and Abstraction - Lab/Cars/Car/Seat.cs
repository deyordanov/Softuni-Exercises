using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Car
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string name, string color)
        {
            this.Model = name;
            this.color = color;
        }
        public string Model 
        { 
            get => this.model;
            set => this.model = value;
        }
        public string Color { 
            get => this.color; 
            set => this.color = value; 
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Start()}\n{this.Stop()}";
        }
    }
}
