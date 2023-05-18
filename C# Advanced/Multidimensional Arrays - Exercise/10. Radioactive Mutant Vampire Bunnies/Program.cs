int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] matrix = new char[size[0], size[1]];
int playerRow = 0;
int playerCol = 0;
for(int row = 0; row < size[0]; row++)
{
    char[] symbols = Console.ReadLine().ToCharArray();
    for(int col = 0; col < size[1]; col++)
    {
        if (symbols[col] == 'P')
        {
            playerRow = row;
            playerCol = col;
            symbols[col] = '.';
        }
        matrix[row, col] = symbols[col];
    }
}

char[] directions = Console.ReadLine().ToCharArray();
foreach(char direction in directions)
{
    switch (direction)
    {
        case 'L':
            PlayerMove(playerRow, playerCol - 1);
            break;
        case 'U':
            PlayerMove(playerRow - 1, playerCol);
            break;
        case 'R':
            PlayerMove(playerRow, playerCol + 1);
            break;
        case 'D':
            PlayerMove(playerRow + 1, playerCol);
            break;
    }
}
void PlayerMove(int row, int col)
{
    if (matrix[playerRow, playerCol] == 'B')
    {
        PrintMatrix();
        Console.WriteLine($"dead: {playerRow} {playerCol}");
        Environment.Exit(0);
    }
    if (row < 0 || row >= matrix.GetLength(0)
        || col < 0 || col >= matrix.GetLength(1))
    {
        SpreadBunnies();
        PrintMatrix();
        Console.WriteLine($"won: {playerRow} {playerCol}");
        Environment.Exit(0);
    }
    if (matrix[row, col] == 'B')
    {
        SpreadBunnies();
        PrintMatrix();
        Console.WriteLine($"dead: {row} {col}");
        Environment.Exit(0);
    }
    playerRow = row;
    playerCol = col;
    SpreadBunnies();
}
void SpreadBunnies()
{
    char[,] copyOfMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            copyOfMatrix[row, col] = matrix[row, col];
        }
    }

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'B' && copyOfMatrix[row, col] == 'B')
            {
                BunniesMove(row, col);
            }
        }
    }
}

void BunniesMove(int row, int col)
{
    if(col - 1 >= 0 && col - 1 < matrix.GetLength(1)) // left
    {
        matrix[row, col - 1] = 'B';
    }
    if(row - 1 >= 0 && row - 1 < matrix.GetLength(0)) // up
    {
        matrix[row - 1, col] = 'B';
    }
    if(col + 1 >= 0 && col + 1 < matrix.GetLength(1)) // right
    {
        matrix[row, col + 1] = 'B';
    }
    if(row + 1 >= 0 && row + 1 < matrix.GetLength(0)) // down
    {
        matrix[row + 1, col] = 'B';
    }
}

void PrintMatrix()
{
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        for(int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}

