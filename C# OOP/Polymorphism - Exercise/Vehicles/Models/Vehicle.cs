using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Exceptions;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuel, double fuelConsumption)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }

        public double Fuel { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double km)
        {
            double neededFuel = km * this.FuelConsumption;
            if(neededFuel > Fuel)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelMessage, this.GetType().Name));
            }
            this.Fuel -= km * this.FuelConsumption;
            return $"{this.GetType().Name} travelled {km} km";
        }

        public virtual void Refuel(double liters)
        {
            this.Fuel += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }
    }
}
