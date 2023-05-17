int size = int.Parse(Console.ReadLine());
int[][] jagged = new int[size][];
jagged[0] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
for (int i = 1; i < size; i++)
{
    jagged[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    if(jagged[i].Length == jagged[i - 1].Length)
    {
        jagged[i] = jagged[i].Select(x => x *= 2).ToArray();
        jagged[i - 1] = jagged[i - 1].Select(x => x *= 2).ToArray();
    }
    else
    {
        jagged[i] = jagged[i].Select(x => x /= 2).ToArray();
        jagged[i - 1] = jagged[i - 1].Select(x => x /= 2).ToArray();
    }
}

string end;
while((end = Console.ReadLine()) != "End")
{
    string[] command = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int row = int.Parse(command[1]);
    int col = int.Parse(command[2]);
    int value = int.Parse(command[3]);
    if(row >= 0 && row < size 
        && col >= 0 && col < jagged[row].Length)
    {
        switch (command[0])
        {
            case "Add":
                jagged[row][col] += value;
                break;
            case "Subtract":
                jagged[row][col] -= value;
                break;
        }
    }
}

foreach (int[] array in jagged)
{
    Console.WriteLine(string.Join(" ", array));
}