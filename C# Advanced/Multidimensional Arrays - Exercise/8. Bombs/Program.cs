int size = int.Parse(Console.ReadLine());
int[,] matrix = new int[size, size];
for(int row = 0; row < size; row++)
{
    int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for(int col = 0; col < size; col++)
    {
        matrix[row, col] = elements[col];
    }
}

string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach(string coordinate in coordinates)
{
    int[] coords = coordinate.Split(",").Select(int.Parse).ToArray();
    if (matrix[coords[0], coords[1]] > 0)
    {
        Explode(coords[0], coords[1], matrix);
    }
}

int aliveCells = 0;
int sumOfAliveCells = 0;
for(int row = 0; row < size; row++)
{
    for(int col = 0; col < size; col++)
    {
        if (matrix[row, col] > 0)
        {
            aliveCells++;
            sumOfAliveCells += matrix[row, col];
        }
    }
}
Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfAliveCells}");

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}
static void Explode(int row, int col, int[,] matrix)
{

    //GOING CLOCKWISE
    int bomb = matrix[row, col];
    if (col - 1 >= 0 && matrix[row, col - 1] > 0) // left
    {
        matrix[row, col - 1] -= bomb;
    }
    if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0) // left - up diagonal
    {
        matrix[row - 1, col - 1] -= bomb;
    }
    if (row - 1 >= 0 && matrix[row - 1, col] > 0) // up
    {
        matrix[row - 1, col] -= bomb;
    }
    if (row - 1 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row - 1, col + 1] > 0) // up - right diagonal
    {
        matrix[row - 1, col + 1] -= bomb;
    }
    if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] > 0) // right
    {
        matrix[row, col + 1] -= bomb;
    }
    if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) && matrix[row + 1, col + 1] > 0) // down - right diagonal
    {
        matrix[row + 1, col + 1] -= bomb;
    }
    if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] > 0) // down
    {
        matrix[row + 1, col] -= bomb;
    }
    if (row + 1 < matrix.GetLength(0) && col - 1 >= 0 && matrix[row + 1, col - 1] > 0) // down - left diagonal
    {
        matrix[row + 1, col - 1] -= bomb;
    }
    matrix[row, col] = 0;
}

