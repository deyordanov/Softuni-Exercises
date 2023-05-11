int foodForTheDay = int.Parse(Console.ReadLine());
Queue<int> clients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
Console.WriteLine(clients.Max());
while(clients.Count > 0)
{
    if (foodForTheDay >= clients.Peek())
    {
        foodForTheDay -= clients.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", clients)}");
        Environment.Exit(0);
    }
}
Console.WriteLine("Orders complete");