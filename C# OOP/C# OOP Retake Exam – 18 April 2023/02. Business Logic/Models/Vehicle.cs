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
        this.maxMileage = maxMileage;
        this.LicensePlateNumber = licensePlateNumber;
        this.batteryLevel = 100;
        this.isDamaged = false;
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

    public double MaxMileage => this.maxMileage;

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

    public int BatteryLevel => this.batteryLevel;

    public bool IsDamaged => this.isDamaged;

    public void Drive(double mileage)
    {
        int batteryUsed = (int)Math.Round((mileage / this.MaxMileage) * 100);
        this.batteryLevel -= batteryUsed;

        if (this.GetType().Name == nameof(CargoVan))
        {
            this.batteryLevel -= 5;
        }
    }

    public void Recharge()
        => this.batteryLevel = 100;

    public void ChangeStatus()
        => this.isDamaged = this.IsDamaged == false ? true : false;

    public override string ToString()
    {
        string damage = this.IsDamaged == false ? "OK" : "damaged";
        return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: {damage}";
    }

}