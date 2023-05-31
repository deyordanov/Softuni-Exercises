using System.Reflection;

namespace Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                double fuel = double.Parse(info[1]);
                double consumption = double.Parse(info[2]);
                cars.Add(new Car(model, fuel, consumption));
            }

            string end;
            while((end = Console.ReadLine()) != "End")
            {
                string[] command = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = command[1];
                double distance = double.Parse(command[2]);
                if(cars.Any(c => c.Model == model))
                {
                    Car car = cars.Where(c => c.Model == model).First();
                    car.Drive(distance);
                }
            }

            foreach(Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}