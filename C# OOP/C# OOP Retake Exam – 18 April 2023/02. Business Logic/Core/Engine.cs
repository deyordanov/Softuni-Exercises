using EDriveRent.Core.Contracts;
using EDriveRent.IO.Contracts;
using EDriveRent.IO;
using System;

namespace EDriveRent.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "RegisterUser")
                    {
                        string firstName = input[1];
                        string lastName = input[2];
                        string drivingLicenseNumber = input[3];

                        result = controller.RegisterUser(firstName, lastName, drivingLicenseNumber);
                    }
                    else if (input[0] == "UploadVehicle")
                    {
                        string vehicleType = input[1];
                        string brand = input[2];
                        string model = input[3];
                        string licensePlateNumber = input[4];

                        result = controller.UploadVehicle(vehicleType, brand, model, licensePlateNumber);
                    }
                    else if (input[0] == "AllowRoute")
                    {
                        string startPoint = input[1];
                        string endPoint = input[2];
                        double length = double.Parse(input[3]);

                        result = controller.AllowRoute(startPoint, endPoint, length);
                    }
                    else if (input[0] == "MakeTrip")
                    {
                        string drivingLicenseNumber = input[1];
                        string licensePlateNumber = input[2];
                        string routeId = input[3];
                        bool isAccidentHappened = bool.Parse(input[4]);

                        result = controller.MakeTrip(drivingLicenseNumber, licensePlateNumber, routeId, isAccidentHappened);
                    }
                    else if (input[0] == "RepairVehicles")
                    {
                        int count = int.Parse(input[1]);

                        result = controller.RepairVehicles(count);
                    }
                    else if (input[0] == "UsersReport")
                    {
                        result = controller.UsersReport();
                    }
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
