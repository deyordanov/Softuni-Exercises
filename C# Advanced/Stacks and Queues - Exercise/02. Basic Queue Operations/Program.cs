int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Queue<int> queue = new Queue<int>();    
for(int i = 0; i < input[0] + input[1]; i++)
{
    string command = i < input[0] ? "Enqueue" : "Dequeue";
    switch (command)
    {
        case "Enqueue":
            queue.Enqueue(numbers[i]);
            break;
        case "Dequeue":
            queue.Dequeue();
            break;
    }
}
Console.WriteLine(Result(queue, input[2]));

static string Result(Queue<int> queue, int numberToFind)
{
    if (queue.Count == 0)
        return "0";

    return queue.Any(x => x == numberToFind) ? "true" : $"{queue.Min()}";
}