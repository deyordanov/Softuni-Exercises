Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
int rackCapacity = int.Parse(Console.ReadLine());
int currentRack = 0;
int racksUsed = 0;
while(clothes.Count > 0)
{
    if(currentRack + clothes.Peek() <= rackCapacity)
    {
        currentRack += clothes.Pop();
    }
    else
    {
        currentRack = 0;
        racksUsed++;
    }
}
Console.WriteLine(racksUsed + 1);