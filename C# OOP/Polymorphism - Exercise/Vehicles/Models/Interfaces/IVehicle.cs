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
        double Fuel { get; }
        double FuelConsumption { get; }
        string Drive(double km);
        void Refuel(double liters);
    }
}
