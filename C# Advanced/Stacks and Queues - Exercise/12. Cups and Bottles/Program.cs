Queue<int> cups = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
int wastedWater = 0;
int currentCup = cups.Peek();
while (cups.Count > 0 && bottles.Count > 0)
{
    currentCup -= bottles.Pop();

    if(currentCup <= 0)
    {
        wastedWater += Math.Abs(currentCup);
        cups.Dequeue();
        if(cups.Count > 0)
            currentCup = cups.Peek();
    }
}
string output = cups.Count == 0 ? $"Bottles: {string.Join(" ", bottles)}"
    : $"Cups: {string.Join(" ", cups)}";
Console.WriteLine(output);
Console.WriteLine($"Wasted litters of water: {wastedWater}");
 