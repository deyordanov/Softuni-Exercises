int[] size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[,] matrix = new int[size[0], size[1]];
for (int row = 0; row < size[0]; row++)
{
    int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < size[1]; col++)
    {
        matrix[row, col] = numbers[col];
    }
    
}

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int currentSum = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        currentSum += matrix[row, col];
    }
    Console.WriteLine(currentSum);
}