using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Exceptions;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string model, double fuel, double fuelConsumption, double tank)
        {
           if(model == "Car")
           {
               return new Car(fuel, fuelConsumption, tank);
           }  
           else if(model == "Truck")
           {
               return new Truck(fuel, fuelConsumption, tank);
           }
           else if(model == "Bus")
            {
                return new Bus(fuel, fuelConsumption, tank);
            }
           else
           {
                throw new NotSupportedVehicleTypeException();
           }
        }
    }
}
