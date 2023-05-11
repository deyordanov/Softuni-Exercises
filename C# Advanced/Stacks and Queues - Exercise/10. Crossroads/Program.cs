int greenLight = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());
Queue<string> cars = new Queue<string>();
int carsPassed = 0;
string end;
while((end = Console.ReadLine()) != "END")
{
    if(end == "green")
    {
        int time = 0;
        while(cars.Count > 0)
        {
            string car = cars.Dequeue();
            for(int i = 0; i < car.Length; i++)
            {
                time++;
                if(time > greenLight + freeWindow)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {car[i]}.");
                    Environment.Exit(0);
                }
            }
            carsPassed++;

            if(time >= greenLight)
            {
                break;
            }

        }
    }
    else
    {
        cars.Enqueue(end);
    }
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carsPassed} total cars passed the crossroads.");