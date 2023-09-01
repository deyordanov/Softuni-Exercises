Queue<Item<int>> queue  = new Queue<Item<int>>();

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

queue.Enqueue(new Item<int>(numbers[0]));

Stack<int> result = new Stack<int>();
while (queue.Count > 0)
{
    Item<int> item = queue.Dequeue();

    if (item.Value < numbers[1])
    {
        queue.Enqueue(new Item<int>(item.Value + 1, item));
        queue.Enqueue(new Item<int>(item.Value + 2, item));
        queue.Enqueue(new Item<int>(item.Value * 2, item));
    }
    else if (item.Value == numbers[1])
    {
        while (item != null)
        {
            result.Push(item.Value);
            item = item.Previous;
        }

        Console.WriteLine(string.Join(" -> ", result));
        return;
    }
}

class Item<T>
{
    public Item(T value, Item<T> previous = null)
    {
        this.Value = value;
        this.Previous = previous;
    }
    public T Value { get; set; }
    public Item<T> Previous { get; set; }
}