namespace EDriveRent.Core;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Models;
using Models.Contracts;
using Repositories;
using Repositories.Contracts;
using Utilities.Messages;

public class Controller : IController
{
    private IRepository<IUser> users;
    private IRepository<IVehicle> vehicles;
    private IRepository<IRoute> routes;

    public Controller()
    {
        this.users = new UserRepository();
        this.vehicles = new VehicleRepository();
        this.routes = new RouteRepository();
    }
    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {
        if (this.users.FindById(drivingLicenseNumber) != null)
        {
            return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }

        this.users.AddModel(new User(firstName, lastName, drivingLicenseNumber));
        return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
    }//

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {
        if (vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
        {
            return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
        }

        if (this.vehicles.FindById(licensePlateNumber) != null)
        {
            return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }

        if (vehicleType == nameof(PassengerCar))
        {
            this.vehicles.AddModel(new PassengerCar(brand, model, licensePlateNumber));
        }
        else if (vehicleType == nameof(CargoVan))
        {
            this.vehicles.AddModel(new CargoVan(brand, model, licensePlateNumber));
        }

        return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
    }//

    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        IRoute existingRoute = this.routes.GetAll().FirstOrDefault(route =>
            route.StartPoint == startPoint && route.EndPoint == endPoint);

        if (existingRoute != null)
        {
            if (existingRoute.Length == length)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            if (existingRoute.Length < length)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            if (existingRoute.Length > length)
            {
                existingRoute.LockRoute();
            }
        }

        this.routes.AddModel(new Route(startPoint, endPoint, length, this.routes.GetAll().Count + 1));
        return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
    }//

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
    {
        IUser user = this.users.FindById(drivingLicenseNumber);
        IVehicle vehicle = this.vehicles.FindById(licensePlateNumber);
        IRoute route = this.routes.FindById(routeId);

        if (user.IsBlocked)
        {
            return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }

        if (vehicle.IsDamaged)
        {
            return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }

        if (route.IsLocked)
        {
            return string.Format(OutputMessages.RouteLocked, routeId);
        }

        vehicle.Drive(route.Length);

        if (isAccidentHappened)
        {
            vehicle.ChangeStatus();
            user.DecreaseRating();
        }
        else
        {
            user.IncreaseRating();
        }

        return vehicle.ToString();
    }//

    public string RepairVehicles(int count)
    {
        List<IVehicle> damagedVehicles = this.vehicles.GetAll().Where(vehicle => vehicle.IsDamaged).OrderBy(vehicle => vehicle.Brand).ThenBy(vehicle => vehicle.Model).Take(count).ToList();

        foreach (IVehicle damagedVehicle in damagedVehicles)
        {
            damagedVehicle.ChangeStatus();
            damagedVehicle.Recharge();
        }

        return string.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
    }//check 

    public string UsersReport()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("*** E-Drive-Rent ***");
        foreach (IUser currentUser in this.users.GetAll().OrderByDescending(user => user.Rating).ThenBy(user => user.LastName).ThenBy(user => user.FirstName))
        {
            sb.AppendLine(currentUser.ToString());
        }

        return sb.ToString().TrimEnd();
    }//
}