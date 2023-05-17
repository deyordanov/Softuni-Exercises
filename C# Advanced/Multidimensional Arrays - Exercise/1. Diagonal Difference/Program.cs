int size = int.Parse(Console.ReadLine());
int[,] matrix = new int[size, size];
int leftDiagonalSum = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for(int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = numbers[col];
    }
    leftDiagonalSum += matrix[row, row];
}

int rightDiagonalSum = 0;
for(int row = 0; row < matrix.GetLength(0); row++)
{
    rightDiagonalSum += matrix[row, matrix.GetLength(1) - row - 1];
}

Console.WriteLine(Math.Abs(rightDiagonalSum - leftDiagonalSum));