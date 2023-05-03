using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.6;
        public Truck(double fuel, double fuelConsumption) : base(fuel, fuelConsumption  + AirConditionerFuelConsumption)
        {
        }

        public override void Refuel(double liters) => base.Refuel(liters * 0.95);
    }
}
