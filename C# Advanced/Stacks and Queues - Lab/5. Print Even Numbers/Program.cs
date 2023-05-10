int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Queue<int> queue = new Queue<int>(numbers.Where(x => x % 2 == 0));
while(queue.Count > 0)
{
    string output = queue.Count == 1 ? queue.Dequeue().ToString() : queue.Dequeue() + ", ";
    Console.Write(output);
}