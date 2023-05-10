int carsThatCanPass = int.Parse(Console.ReadLine());
Queue<string> queue = new Queue<string>();
string end;
int carsPassed = 0;
while((end = Console.ReadLine()) != "end")
{
    string input = end;
    if(input == "green")
    {
        int carsToPass = queue.Count < carsThatCanPass ? queue.Count : carsThatCanPass;
        for (int i = 0; i < carsToPass; i++)
        {
            Console.WriteLine($"{queue.Dequeue()} passed!");
            carsPassed++;
        }
    }
    else
    {
        queue.Enqueue(input);
    }
}
Console.WriteLine($"{carsPassed} cars passed the crossroads.");