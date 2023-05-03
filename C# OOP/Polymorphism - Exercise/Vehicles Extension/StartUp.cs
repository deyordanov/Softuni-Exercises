using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Models;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory factory = new VehicleFactory();
Engine engine = new Engine(reader, writer, factory);
engine.Run();
