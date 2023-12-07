using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Exam.MobileX
{
    using System.Linq;

    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, Dictionary<string, Vehicle>> vehiclesBySellerAndId;

        private Dictionary<VehicleKey, Dictionary<string, Vehicle>> vehiclesByKeys;

        private Dictionary<double, Dictionary<string, Vehicle>> vehiclesByPriceAndId;

        private Dictionary<string, Vehicle> allVehicles;

        private Dictionary<string, List<Vehicle>> vehiclesInOrderOfAddition;

        private SortedSet<Vehicle> sortedVehicles;

        private class VehicleKey
        {
            public VehicleKey(string brand, string model, string location, string color)
            {
                Brand = brand;
                Model = model;
                Location = location;
                Color = color;
            }

            public string Brand { get; set; }

            public string Model { get; set; }

            public string Location { get; set; }

            public string Color { get; set; }


            public override bool Equals(object obj)
            {
                if (obj is VehicleKey other)
                {
                    return Brand == other.Brand && Model == other.Model && Location == other.Location && Color == other.Color;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Brand, Model, Location, Color);
            }
        }

        public VehicleRepository()
        {
            this.vehiclesBySellerAndId = new Dictionary<string, Dictionary<string, Vehicle>>();
            this.vehiclesByKeys = new Dictionary<VehicleKey, Dictionary<string, Vehicle>>();
            this.vehiclesByPriceAndId = new Dictionary<double, Dictionary<string, Vehicle>>();
            this.allVehicles = new Dictionary<string, Vehicle>();
            this.vehiclesInOrderOfAddition = new Dictionary<string, List<Vehicle>>();
            this.sortedVehicles = new SortedSet<Vehicle>(new SortedVehiclesComparer());
        }

        public int Count => this.allVehicles.Count;

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!this.vehiclesBySellerAndId.ContainsKey(sellerName))
            {
                this.vehiclesBySellerAndId.Add(sellerName, new Dictionary<string, Vehicle>());
            }

            if (!this.vehiclesInOrderOfAddition.ContainsKey(sellerName))
            {
                this.vehiclesInOrderOfAddition.Add(sellerName, new List<Vehicle>());
            }

            if (!this.vehiclesBySellerAndId[sellerName].ContainsKey(vehicle.Id))
            {
                vehicle.SellerName = sellerName;

                VehicleKey key = new VehicleKey(vehicle.Brand, vehicle.Model, vehicle.Location, vehicle.Color);

                //By Keys
                if (!this.vehiclesByKeys.ContainsKey(key))
                {
                    this.vehiclesByKeys.Add(key, new Dictionary<string, Vehicle>());
                }

                if (!this.vehiclesByKeys[key].ContainsKey(vehicle.Id))
                {
                    this.vehiclesByKeys[key].Add(vehicle.Id, vehicle);
                }

                //In Order Of Addition
                this.vehiclesInOrderOfAddition[sellerName].Add(vehicle);

                //By Seller
                this.vehiclesBySellerAndId[sellerName].Add(vehicle.Id, vehicle);

                //By Price
                if (!this.vehiclesByPriceAndId.ContainsKey(vehicle.Price))
                {
                    this.vehiclesByPriceAndId.Add(vehicle.Price, new Dictionary<string, Vehicle>());
                }

                if (!this.vehiclesByPriceAndId[vehicle.Price].ContainsKey(vehicle.Id))
                {
                    this.vehiclesByPriceAndId[vehicle.Price].Add(vehicle.Id, vehicle);
                }

                //All
                this.allVehicles.Add(vehicle.Id, vehicle);

                //Sorted 
                this.sortedVehicles.Add(vehicle);
            }
        }

        public bool Contains(Vehicle vehicle) => this.allVehicles.ContainsKey(vehicle.Id);

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            HashSet<Vehicle> matchedVehicles = new HashSet<Vehicle>();

            foreach (var attribute in vehiclesByKeys)
            {
                if (keywords.Contains(attribute.Key.Brand) ||
                    keywords.Contains(attribute.Key.Model) ||
                    keywords.Contains(attribute.Key.Location) ||
                    keywords.Contains(attribute.Key.Color))
                {
                    foreach (var vehicle in attribute.Value.Values)
                    {
                        matchedVehicles.Add(vehicle);
                    }
                }
            }

            return matchedVehicles.OrderByDescending(v => v.IsVIP).ThenBy(v => v.Price);
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.vehiclesInOrderOfAddition.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            if (this.vehiclesInOrderOfAddition[sellerName].Count == 0)
            {
                throw new ArgumentException();
            }

            return this.vehiclesInOrderOfAddition[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            var vehicles = this.vehiclesByPriceAndId
                .Where(kvp => kvp.Key >= lowerBound && kvp.Key <= upperBound)
                .SelectMany(v => v.Value.Values);

            return vehicles
                .OrderByDescending(v => v.Horsepower);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (this.vehiclesByKeys.Count == 0)
            {
                throw new ArgumentException();
            }

            var groupedByBrand = new Dictionary<string, List<Vehicle>>();

            foreach (var key in this.vehiclesByKeys)
            {
                string brand = key.Key.Brand;
                var vehicles = key.Value.Values;

                if (!groupedByBrand.ContainsKey(brand))
                {
                    groupedByBrand[brand] = new List<Vehicle>();
                }

                foreach (var vehicle in vehicles)
                {
                    groupedByBrand[brand].Add(vehicle);
                }
            }

            foreach (var brand in groupedByBrand.Keys.ToList())
            {
                groupedByBrand[brand] = groupedByBrand[brand].OrderBy(v => v.Price).ToList();
            }

            return groupedByBrand;
        }


        public void RemoveVehicle(string vehicleId)
        {
            if (!this.allVehicles.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            Vehicle vehicle = this.allVehicles[vehicleId];

            VehicleKey key = new VehicleKey(vehicle.Brand, vehicle.Model, vehicle.Location, vehicle.Color);

            this.vehiclesBySellerAndId[vehicle.SellerName].Remove(vehicleId);
            this.vehiclesByKeys[key].Remove(vehicle.Id);
            this.vehiclesByPriceAndId[vehicle.Price].Remove(vehicleId);
            this.allVehicles.Remove(vehicleId);
            this.vehiclesInOrderOfAddition[vehicle.SellerName].Remove(vehicle);
            this.sortedVehicles.Remove(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            return this.sortedVehicles;
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.vehiclesBySellerAndId.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            Vehicle vehicle = this.vehiclesBySellerAndId[sellerName]
                .Select(kvp => kvp.Value)
                .OrderBy(v => v.Price)
                .FirstOrDefault();

            if (vehicle == null)
            {
                throw new ArgumentException();
            }

            this.RemoveVehicle(vehicle.Id);

            return vehicle;
        }

        private class SortedVehiclesComparer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int result = y.Horsepower.CompareTo(x.Horsepower);
                if (result == 0)
                {
                    result = x.Price.CompareTo(y.Price);
                }
                if (result == 0)
                {
                    result = String.Compare(x.SellerName, y.SellerName, StringComparison.Ordinal);
                }
                return result;
            }
        }
    }
}
