using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double Tank { get; }
        double Fuel { get; }
        double FuelConsumption { get; }
        double AirConditionerFuelConsumption { get; }
        string Drive(double km, bool passengers);
        void Refuel(double liters);
    }
}
