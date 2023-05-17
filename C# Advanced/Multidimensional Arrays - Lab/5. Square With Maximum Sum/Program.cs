int[] size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[,] matrix = new int[size[0], size[1]];
for (int row = 0; row < size[0]; row++)
{
    int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < size[1]; col++)
    {
        matrix[row, col] = numbers[col];
    }
}

int maxSum = int.MinValue;
int maxRow = 0;
int maxCol = 0;
for(int row = 0; row < matrix.GetLength(0); row++)
{
    for(int col = 0; col < matrix.GetLength(1); col++)
    {
        int sum = 0;
        if (col + 1 < matrix.GetLength(1)
            && row + 1 < matrix.GetLength(0))
        {
            sum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
        }
        if (sum > maxSum)
        {
            maxRow = row;
            maxCol = col;
            maxSum = sum;
        }
    }
}

for(int row = maxRow; row <= maxRow + 1; row++)
{
    for(int col = maxCol; col <= maxCol + 1; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine(maxSum);