namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                info = Input(info);
                string model = info[0];
                int power = int.Parse(info[1]);
                int dis = int.Parse(info[2]);
                string eff = info[3];
                engines.Add(new Engine(model, power, dis, eff));
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for( int i = 0; i < m; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                info = Input(info);
                string model = info[0]; 
                string engine = info[1];
                int weight = int.Parse(info[2]);
                string color = info[3];
                cars.Add(new Car(model, engines.Where(e => e.Model == engine).First(), weight, color));
            }

            foreach(Car car in cars )
            {
                Console.WriteLine(car);
            }

            string[] Input(string[] info)
            {
                int intValue = 0;
                string stringValue = null;
                if(info.Length == 2)
                {
                    return new string[4] { info[0], info[1], intValue.ToString(), stringValue };
                }
                else if(info.Length == 3)
                {
                    intValue = char.IsDigit(info[2][0]) ? int.Parse(info[2]) : 0;
                    stringValue = char.IsLetter(info[2][0]) ? info[2] : null;
                    return new string[4] { info[0], info[1], intValue.ToString(), stringValue};
                }
                else
                {
                    intValue = int.Parse(info[2]);
                    stringValue = info[3];
                    return new string[4] { info[0], info[1], intValue.ToString(), stringValue };
                }
            }
        }
    }
}