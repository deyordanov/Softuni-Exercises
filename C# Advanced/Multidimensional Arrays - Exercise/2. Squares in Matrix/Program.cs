int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
string[,] matrix = new string[size[0], size[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for(int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = numbers[col];
    }
}

int sizeOfSquare = 2; // by changing this value we can check not only 2 x 2 squares, but 3 x 3, 4 x 4, etc...
int count = 0;
for(int rows = 0; rows < matrix.GetLength(0); rows++)
{
    for(int cols = 0; cols < matrix.GetLength(1); cols++)
    {
        if (rows + sizeOfSquare <= matrix.GetLength(0) && cols + sizeOfSquare <= matrix.GetLength(1))
        {
            bool valid = true;
            string symbol = matrix[rows, cols];
            for(int row = rows; row < rows + sizeOfSquare; row++)
            {
                for(int col = cols; col < cols + sizeOfSquare; col++)
                {
                    if (matrix[row, col] != symbol)
                    {
                        row = rows + sizeOfSquare;
                        valid = false;
                        break;
                    }
                }
            }
            if (valid)
            {
                count++;
            }
        }
    }
}
Console.WriteLine(count);