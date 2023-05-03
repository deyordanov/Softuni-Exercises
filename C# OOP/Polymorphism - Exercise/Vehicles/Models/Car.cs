using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelConsumption = 0.9;
        public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption + AirConditionerFuelConsumption)
        {
        }
    }
}
