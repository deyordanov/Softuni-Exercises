using PrototypeDesignPattern.Vehicles;

List<Vehicle> vehicles = new List<Vehicle>()
{
    new Car(
        "car_brand", 
        "car_model", 
        "car_color", 
        "car_top_speed"),
    new Bus(
        "bus_brand",
        "bus_model",
        "bus_color",
        8),
};

List<Vehicle> vehicleClones = new List<Vehicle>();

foreach (Vehicle vehicle in vehicles)
{
    vehicleClones.Add(vehicle.Clone());
}

Console.WriteLine("<======================>");
foreach (Vehicle copy in vehicleClones)
{
    Console.WriteLine(copy);
    Console.WriteLine("<======================>");
}