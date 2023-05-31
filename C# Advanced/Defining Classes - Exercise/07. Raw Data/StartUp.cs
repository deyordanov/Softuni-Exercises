using System.Runtime.CompilerServices;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                int speed = int.Parse(info[1]);
                int power = int.Parse(info[2]);
                int weight = int.Parse(info[3]);
                string type = info[4];
                double pressure1 = double.Parse(info[5]);
                int year1 = int.Parse(info[6]);
                double pressure2 = double.Parse(info[7]);
                int year2 = int.Parse(info[8]);
                double pressure3 = double.Parse(info[9]);
                int year3 = int.Parse(info[10]);
                double pressure4 = double.Parse(info[11]);
                int year4 = int.Parse(info[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                Tire[] tires = new Tire[4]
                {
                    new Tire(pressure1, year1),
                    new Tire(pressure2, year2),
                    new Tire(pressure3, year3),
                    new Tire(pressure4, year4)
                };
                cars.Add(new Car(model, engine, tires, cargo));
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1)).Select(c => $"{c.Model}")));
                    break;
                case "flammable":
                    Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == command && c.Engine.Power > 250).Select(c => $"{c.Model}")));
                    break;
            }
        }
    }
}