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
        protected Vehicle(double fuel, double fuelConsumption, double tank)
        {
            Tank = tank;
            Fuel = fuel > tank ? 0 : fuel;
            FuelConsumption = fuelConsumption;
        }

        public double Tank { get; private set; }
        public double Fuel { get; private set; }
        public double FuelConsumption { get; private set; }
        public abstract double AirConditionerFuelConsumption { get; }


        public string Drive(double km, bool passengers)
        {

            double neededFuel = passengers ? km * (this.FuelConsumption + this.AirConditionerFuelConsumption) : km * this.FuelConsumption;
            if(neededFuel > Fuel)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelMessage, this.GetType().Name));
            }
            this.Fuel -= neededFuel;
            return $"{this.GetType().Name} travelled {km} km";
        }

        public virtual void Refuel(double liters)
        {
            if(liters <= 0)
            {
                throw new InvalidFuelAmountException();
            }
            if(this.Fuel + liters > this.Tank)
            {
                throw new CannotFitFuelException(string.Format(ExceptionMessages.CannotFitFuelMessage, liters));
            }
            this.Fuel += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }
    }
}
