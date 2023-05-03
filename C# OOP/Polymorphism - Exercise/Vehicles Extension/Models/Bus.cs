using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private double additionalConsumption;
        public Bus(double fuel, double fuelConsumption, double tank) : base(fuel, fuelConsumption, tank)
        {
            additionalConsumption = 1.4;
        }

        public override double AirConditionerFuelConsumption => this.additionalConsumption;
    }
}
