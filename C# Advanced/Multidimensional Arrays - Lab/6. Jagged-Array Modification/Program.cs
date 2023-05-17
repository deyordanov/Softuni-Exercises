int rows = int.Parse(Console.ReadLine());
int[][] jagged = new int[rows][];
for(int row = 0; row < rows; row++)
{
    jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();  
}

string end;
while ((end = Console.ReadLine()) != "END")
{
    string[] command = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int row = int.Parse(command[1]);
    int col = int.Parse(command[2]);
    int value = int.Parse(command[3]);
    bool validCoord = row >= rows || row < 0 || col < 0 || col >= jagged[row].Length ? false : true;
    if (!validCoord)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }
    if (command[0] == "Add")
    {
        jagged[row][col] += value;
    }
    else if (command[0] == "Subtract")
    {
        jagged[row][col] -= value;
    }
}

foreach(int[] array in jagged)
{
    Console.WriteLine(string.Join(" ", array));
}