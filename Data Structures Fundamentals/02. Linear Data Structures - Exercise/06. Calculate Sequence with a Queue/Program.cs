int n = int.Parse(Console.ReadLine());

Queue<int> queue =  new Queue<int>();
queue.Enqueue(n);

List<int> items = new List<int>();
for (int i = 0; i < 12; i++)
{
    int num1 = queue.Dequeue();
    int num2 = num1 + 1;
    int num3 = 2 * num1 + 1;
    int num4 = num1 + 2;
    queue.Enqueue(num2);
    queue.Enqueue(num3);
    queue.Enqueue(num4);
    items.Add(num2);
    items.Add(num3);
    items.Add(num4);    
}

Console.WriteLine(string.Join(" ", items));