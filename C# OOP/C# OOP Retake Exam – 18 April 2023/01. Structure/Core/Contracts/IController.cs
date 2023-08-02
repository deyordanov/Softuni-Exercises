namespace EDriveRent.Core.Contracts
{
    public interface IController
    {
        string RegisterUser(string firstName, string lastName, string drivingLicenseNumber);
        string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber);
        string AllowRoute(string startPoint, string endPoint, double length);
        string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened);
        string RepairVehicles(int count);
        string UsersReport();
    }
}
