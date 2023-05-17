int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[,] matrix = new int[size[0], size[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = numbers[col];
    }
}

int sizeOfSquare = 3; // by changing this value we can check not only 2 x 2 squares, but 3 x 3, 4 x 4, etc...
int maxSum = int.MinValue;
int maxRow = 0;
int maxCol = 0;
for (int rows = 0; rows < matrix.GetLength(0); rows++)
{
    for (int cols = 0; cols < matrix.GetLength(1); cols++)
    {
        if (rows + sizeOfSquare <= matrix.GetLength(0) && cols + sizeOfSquare <= matrix.GetLength(1))
        {
            int sum = 0;
            for (int row = rows; row < rows + sizeOfSquare; row++)
            {
                for (int col = cols; col < cols + sizeOfSquare; col++)
                {
                    sum += matrix[row, col];
                }
            }
            if(sum > maxSum)
            {
                maxRow = rows;
                maxCol = cols;
                maxSum = sum;
            }
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");
for(int row = maxRow; row < maxRow + sizeOfSquare; row++)
{
    for(int col = maxCol; col < maxCol + sizeOfSquare; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}