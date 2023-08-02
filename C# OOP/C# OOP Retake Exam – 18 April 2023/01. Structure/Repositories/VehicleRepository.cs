namespace EDriveRent.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class VehicleRepository : IRepository<IVehicle>
{
    private List<IVehicle> vehicles;

    public VehicleRepository()
    {
        this.vehicles = new List<IVehicle>();
    }
    public void AddModel(IVehicle model)
        => this.vehicles.Add(model);

    public bool RemoveById(string identifier)
        => this.vehicles.Remove(this.vehicles.FirstOrDefault(vehicle => vehicle.LicensePlateNumber == identifier));

    public IVehicle FindById(string identifier)
        => this.vehicles.FirstOrDefault(vehicle => vehicle.LicensePlateNumber == identifier);

    public IReadOnlyCollection<IVehicle> GetAll()
        => this.vehicles.AsReadOnly();
}