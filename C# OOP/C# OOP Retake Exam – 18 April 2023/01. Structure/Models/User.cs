namespace EDriveRent.Models;

using System;
using Contracts;
using Utilities.Messages;

public class User : IUser
{
    private string firstName;
    private string lastName;
    private double rating;
    private string drivingLicenseNumber;
    private bool isBlocked;

    public User(string firstName, string lastName, string drivingLicense)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.DrivingLicenseNumber = drivingLicense;
        this.Rating = 0;
        this.IsBlocked = false;
    }

    public string FirstName
    {
        get => this.firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FirstNameNull);
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LastNameNull);
            }

            this.lastName = value;
        }
    }

    public double Rating
    {
        get => this.rating;
        private set => this.rating = value;
    }

    public string DrivingLicenseNumber
    {
        get => this.drivingLicenseNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
            }

            this.drivingLicenseNumber = value;
        }
    }

    public bool IsBlocked
    {
        get => this.isBlocked;
        private set => this.isBlocked = value;
    }

    public void IncreaseRating()
    {
        this.Rating += 0.5;
        if (this.Rating > 10.0)
        {
            this.Rating = 10.0;
        }
    }

    public void DecreaseRating()
    {
        this.Rating -= 2;
        if (this.Rating < 0)
        {
            this.IsBlocked = true;
            this.Rating = 0;
        }
    }

    public override string ToString()
        => $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";

}