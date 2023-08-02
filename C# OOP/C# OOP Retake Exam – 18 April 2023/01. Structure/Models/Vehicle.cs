namespace EDriveRent.Models;

using System;
using Contracts;
using Utilities.Messages;

public abstract class Vehicle : IVehicle
{
    private string brand;
    private string model;
    private double maxMileage;
    private string licensePlateNumber;
    private int batteryLevel;
    private bool isDamaged;

    public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
    {
        this.Brand = brand;
        this.Model = model;
        this.MaxMileage = maxMileage;
        this.LicensePlateNumber = licensePlateNumber;
        this.BatteryLevel = 100;
        this.IsDamaged = false;
    }

    public string Brand
    {
        get => this.brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandNull);
            }

            this.brand = value;
        }
    }

    public string Model
    {
        get => this.model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNull);
            }

            this.model = value;
        }
    }

    public double MaxMileage
    {
        get => this.maxMileage;
        private set => this.maxMileage = value;
    }

    public string LicensePlateNumber
    {
        get => this.licensePlateNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
            }

            this.licensePlateNumber = value;
        }
    }

    public int BatteryLevel
    {
        get => this.batteryLevel;
        private set => this.batteryLevel = value;
    }

    public bool IsDamaged
    {
        get => this.isDamaged;
        private set => this.isDamaged = value;
    }

    public void Drive(double mileage)
        => this.BatteryLevel -= (int)Math.Round(this.GetType().Name == "CargoVan"
            ? (mileage / this.MaxMileage) * 105
            : (mileage / this.MaxMileage) * 100);

    public void Recharge()
        => this.BatteryLevel = 100;

    public void ChangeStatus()
        => this.IsDamaged = this.IsDamaged == false ? true : false;

    public override string ToString()
    {
        string damage = this.IsDamaged == false ? "OK" : "damaged";
        return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status {damage}";
    }

}