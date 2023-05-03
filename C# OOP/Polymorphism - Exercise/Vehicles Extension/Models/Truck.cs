using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double additionalConsumption;
        public Truck(double fuel, double fuelConsumption, double tank) : base(fuel, fuelConsumption, tank)
        {
            additionalConsumption = 1.6;
        }

        public override double AirConditionerFuelConsumption => this.additionalConsumption;

        public override void Refuel(double liters) => base.Refuel(Fuel + liters > Tank ? liters : liters * 0.95);
    }
}
