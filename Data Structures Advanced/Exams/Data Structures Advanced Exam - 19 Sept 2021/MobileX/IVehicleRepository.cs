using System.Collections.Generic;

namespace Exam.MobileX
{
    public interface IVehicleRepository
    {
        void AddVehicleForSale(Vehicle vehicle, string sellerName);

        void RemoveVehicle(string vehicleId);

        int Count { get; }

        bool Contains(Vehicle vehicle);

        IEnumerable<Vehicle> GetVehicles(List<string> keywords);

        IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName);

        IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound);

        Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand();

        IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName();

        Vehicle BuyCheapestFromSeller(string sellerName);
    }
}
