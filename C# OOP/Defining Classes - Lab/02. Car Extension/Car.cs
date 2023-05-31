using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get => this.make;
            set => this.make = value;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if(fuelNeeded <= this.FuelQuantity)
            {
                this.fuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
