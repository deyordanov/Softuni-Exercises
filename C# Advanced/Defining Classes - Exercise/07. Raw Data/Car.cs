using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Tire[] tires, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Tires = tires;
            this.Cargo = cargo;
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
        public Cargo Cargo { get; set; }
    }
}
