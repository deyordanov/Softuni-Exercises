int[] size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[,] matrix = new int[size[0],size[1]];
int sum = 0;
for (int row = 0; row < size[0]; row++)
{
    int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < size[1]; col++)
    {
        matrix[row, col] = numbers[col];
        sum += numbers[col];
    }
}

Console.WriteLine(size[0]);
Console.WriteLine(size[1]);
Console.WriteLine(sum);
