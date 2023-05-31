namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tire;
            Dictionary<int, Tire[]> tires = new Dictionary<int, Tire[]>();
            int index = 0;
            while((tire = Console.ReadLine()) != "No more tires")
            {
                string[] info = tire.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                tires.Add(index, new Tire[4]);
                tires[index][0] = new Tire(int.Parse(info[0]), double.Parse(info[1]));
                tires[index][1] = new Tire(int.Parse(info[2]), double.Parse(info[3]));
                tires[index][2] = new Tire(int.Parse(info[4]), double.Parse(info[5]));
                tires[index++][3] = new Tire(int.Parse(info[6]), double.Parse(info[7]));
            }

            string engine;
            Dictionary<int, Engine> engines = new Dictionary<int, Engine>();
            index = 0;
            while((engine = Console.ReadLine()) != "Engines done")
            {
                string[] info = engine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                engines.Add(index++, new Engine(int.Parse(info[0]), double.Parse(info[1])));
            }

            string end;
            List<Car> cars = new List<Car>();   
            while((end = Console.ReadLine()) != "Show special")
            {
                string[] info = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = info[0];
                string model = info[1];
                int year = int.Parse(info[2]);
                double fuelQuantity = double.Parse(info[3]);
                double fuelConsumption = double.Parse(info[4]);
                int engineIndex  = int.Parse(info[5]);
                int tireIndex = int.Parse(info[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
                cars.Add(car);
            }

            foreach(Car car in cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330))
            {
                double pressureSum = 0;
                for(int i = 0; i < car.Tires.Length; i++)
                {
                    pressureSum += car.Tires[i].Pressure;
                }
                if(pressureSum >= 9 && pressureSum <= 10)
                {
                    car.Drive(20.0);
                    Console.WriteLine(car);
                }
            }
        }
    }
}