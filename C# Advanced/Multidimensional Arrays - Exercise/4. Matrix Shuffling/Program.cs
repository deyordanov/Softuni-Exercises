int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
string[,] matrix = new string[size[0], size[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = symbols[col];
    }
}

string end;
while((end = Console.ReadLine()) != "END")
{
    string[] command = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (command.Length != 5 || command[0] != "swap"
            || int.Parse(command[2]) < 0 || int.Parse(command[2]) >= matrix.GetLength(1)
            || int.Parse(command[4]) < 0 || int.Parse(command[4]) >= matrix.GetLength(1)
            || int.Parse(command[1]) < 0 || int.Parse(command[1]) >= matrix.GetLength(0)
            || int.Parse(command[3]) < 0 || int.Parse(command[3]) >= matrix.GetLength(0))
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    int Y1 = int.Parse(command[1]); // row 1
    int X1 = int.Parse(command[2]); // col 1
    int Y2 = int.Parse(command[3]); // row 2
    int X2 = int.Parse(command[4]); // col 2

    string element = matrix[Y1, X1];
    matrix[Y1, X1] = matrix[Y2, X2];
    matrix[Y2, X2] = element;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}