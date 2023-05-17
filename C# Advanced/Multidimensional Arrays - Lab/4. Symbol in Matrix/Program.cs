int size = int.Parse(Console.ReadLine());
char[,] matrix = new char[size, size];
for(int row = 0; row < size; row++)
{
    char[] symbols = Console.ReadLine().ToCharArray();
    for(int col = 0; col < size; col++)
    {
        matrix[row, col] = symbols[col];
    }
}

char symbol = char.Parse(Console.ReadLine());
for (int row = 0; row < size; row++)
{ 
    for (int col = 0; col < size; col++)
    {
        if (matrix[row, col] == symbol)
        {
            Console.WriteLine($"({row}, {col})");
            return;
        }
    }
}
Console.WriteLine($"{symbol} does not occur in the matrix");