int n = int.Parse(Console.ReadLine());
Queue<int> km  = new Queue<int>();
Queue<int> fuel = new Queue<int>();   
for(int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    km.Enqueue(input[1]);
    fuel.Enqueue(input[0]);
}
int stations = 0;
int smallestIndex = 0;
int currentIndex = 0;
int currentFuel = fuel.Peek();
while(stations <= n)
{
    if(stations == 0)
    {
        smallestIndex = currentIndex;
    }
    if(currentFuel >= km.Peek())
    {
        currentFuel -= km.Peek();
        stations++;
        fuel.Enqueue(fuel.Dequeue());
        km.Enqueue(km.Dequeue());
        currentFuel += fuel.Peek();
    }
    else
    {
        stations = 0;
        fuel.Enqueue(fuel.Dequeue());
        km.Enqueue(km.Dequeue());
        currentFuel = fuel.Peek();
    }
    currentIndex++;
}
Console.WriteLine(smallestIndex);