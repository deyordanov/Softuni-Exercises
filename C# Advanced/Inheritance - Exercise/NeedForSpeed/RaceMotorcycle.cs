using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int power, double fuel) : base(power, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;

    }
}
