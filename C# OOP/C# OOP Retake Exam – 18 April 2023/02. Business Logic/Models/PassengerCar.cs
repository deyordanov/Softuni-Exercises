namespace EDriveRent.Models;

public class PassengerCar : Vehicle
{
    private const double maxMileage = 450; 
    public PassengerCar(string brand, string model, string licensePlateNumber) : base(brand, model, maxMileage, licensePlateNumber)
    {
    }
}