using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Exceptions;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IVehicleFactory factory;

        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer, IVehicleFactory factory)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
        }
        public void Run()
        {
            vehicles.Add(this.BuildVehicleWithFactory());
            vehicles.Add(this.BuildVehicleWithFactory());
            vehicles.Add(this.BuildVehicleWithFactory());

            int n = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] vehicleArgs = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmdArg = vehicleArgs[0];
                string model = vehicleArgs[1];
                double arg = double.Parse(vehicleArgs[2]);
                try
                {
                    IVehicle currentVehicle = this.vehicles
                        .FirstOrDefault(v => v.GetType().Name == model);
                    if (cmdArg == null)
                    {
                        throw new NotSupportedVehicleTypeException();
                    }
                    else if (cmdArg == "Drive")
                    {
                        this.writer.WriteLine(currentVehicle.Drive(arg, true));
                    }
                    else if(cmdArg == "DriveEmpty")
                    {
                        this.writer.WriteLine(currentVehicle.Drive(arg, false));
                    }
                    else if (cmdArg == "Refuel")
                    {
                        currentVehicle.Refuel(arg);
                    }
                }
                catch(InsufficientFuelException ide)
                {
                    this.writer.WriteLine(ide.Message);
                }
                catch(NotSupportedVehicleTypeException nsvte)
                {
                    this.writer.WriteLine(nsvte.Message);
                }
                catch(CannotFitFuelException cffe)
                {
                    this.writer.WriteLine(cffe.Message);
                }
                catch(InvalidFuelAmountException ifae)
                {
                    this.writer.WriteLine(ifae.Message);
                }
                catch(Exception)
                {
                    throw;
                }
            }
            foreach(IVehicle vehicle in vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle BuildVehicleWithFactory()
        {
            string[] vehicleArgs = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = vehicleArgs[0];
            double fuel = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tank = double.Parse(vehicleArgs[3]);
            return factory.CreateVehicle(model, fuel, fuelConsumption, tank);
        }
    }
}
