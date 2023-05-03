using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private double additionalConsumption;
        public Car(double fuel, double fuelConsumption, double tank) : base(fuel, fuelConsumption, tank)
        {
            additionalConsumption = 0.9;
        }

        public override double AirConditionerFuelConsumption => this.additionalConsumption;
    }
}
