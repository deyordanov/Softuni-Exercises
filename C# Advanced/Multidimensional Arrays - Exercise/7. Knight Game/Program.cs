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

int knightsToBeRemoved = 0;
while (true)
{
    int mostAttackedKnights = 0;
    int attackedRow = -1;
    int attackedCol = -1;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'K')
            {
                int attackedKnights = Attack(row, col, matrix);
                if (attackedKnights > mostAttackedKnights)
                {
                    attackedRow = row;
                    attackedCol = col;
                    mostAttackedKnights = attackedKnights;
                }
            }
        }
    }

    if(attackedRow == -1 && attackedCol == -1)
    {
        break;
    }
    else
    {
        matrix[attackedRow, attackedCol] = '0';
        knightsToBeRemoved++;
    }
}
Console.WriteLine(knightsToBeRemoved);

static int Attack(int row, int col, char[,] matrix)
{
    int attackedKnights = 0;
    //VERTICAL
    if(row - 2 >= 0 && col + 1 < matrix.GetLength(1)) //up - right
    {
        attackedKnights = matrix[row - 2, col + 1] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(row - 2 >= 0 && col - 1 >= 0) // up - left
    {
        attackedKnights = matrix[row - 2, col - 1] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1)) // down - right
    {
        attackedKnights = matrix[row + 2, col + 1] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(row + 2 < matrix.GetLength(0) && col - 1 >= 0) // down - left
    {
        attackedKnights = matrix[row + 2, col - 1] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    //HORIZONTAL
    if(col + 2 < matrix.GetLength(1) && row - 1 >= 0) //right - up
    {
        attackedKnights = matrix[row - 1, col + 2] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(col + 2 < matrix.GetLength(1) && row + 1 < matrix.GetLength(0)) // righ - down
    {
        attackedKnights = matrix[row + 1, col + 2] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(col - 2 >= 0 && row - 1 >= 0) // left - up
    {
        attackedKnights = matrix[row - 1, col - 2] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    if(col - 2 >= 0 && row + 1 < matrix.GetLength(0)) // left - down
    {
        attackedKnights = matrix[row + 1, col - 2] == 'K' ? attackedKnights + 1 : attackedKnights;
    }
    return attackedKnights;
}