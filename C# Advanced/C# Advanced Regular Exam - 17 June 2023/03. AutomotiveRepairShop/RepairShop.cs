using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int cap)
        {
            Capacity = cap;
            Vehicles = new List<Vehicle>();  
        }
        public List<Vehicle> Vehicles { get; set; }
        public int Capacity { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if(Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            if(Vehicles.Any(v => v.VIN == vin))
            {
                Vehicles = Vehicles.Where(v => v.VIN != vin).ToList();
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(v => v.Mileage).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach(Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
