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
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DrivingLicenseNumber = drivingLicense;
        this.rating = 0;
        this.isBlocked = false;
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

    public double Rating => this.rating;

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

    public bool IsBlocked => this.isBlocked;

    public void IncreaseRating()
    {
        this.rating += 0.5;
        if (this.rating > 10.0)
        {
            this.rating = 10.0;
        }
    }//

    public void DecreaseRating()
    {
        this.rating -= 2.0;
        if (this.rating < 0.0)
        {
            this.isBlocked = true;
            this.rating = 0.0;
        }
    }//

    public override string ToString()
        => $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";

}