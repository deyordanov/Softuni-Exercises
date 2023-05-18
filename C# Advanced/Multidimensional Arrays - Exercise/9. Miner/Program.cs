int size = int.Parse(Console.ReadLine());
string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[,] matrix = new string[size, size];
int startingRow = 0;
int startingCol = 0;
int totalCoal = 0;
for(int row = 0; row < size; row++)
{
    string[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for(int col = 0; col < size; col++)
    {
        matrix[row, col] = symbols[col];
        switch (symbols[col])
        {
            case "s":
                startingRow = row;
                startingCol = col;
                break;
            case "c":
                totalCoal++;
                break;
        }
    }
}

int gatheredCoal = 0;

foreach(string direction in directions)
{
    string[] input = OutOfPlayfield(direction, startingRow, startingCol, matrix);
    if (input[0] == "false")
    {
        int row = int.Parse(input[1]);
        int col = int.Parse(input[2]);
        CoalOrExit(row, col, matrix);
        matrix[startingRow, startingCol] = "*";
        matrix[row, col] = "s";
        startingRow = row;
        startingCol = col;
    }
}

Console.WriteLine($"{totalCoal - gatheredCoal} coals left. ({startingRow}, {startingCol})");
string[] OutOfPlayfield(string direction, int row, int col, string[,] matrix)
{
    string validate = string.Empty;
    switch (direction)
    {
        case "left":
            validate = col - 1 >= 0 && col - 1 < matrix.GetLength(1) ? "false" : "true";
            col -= 1;
            break;
        case "up":
            validate = row - 1 >= 0 && row - 1 < matrix.GetLength(0) ? "false" : "true";
            row -= 1;
            break;
        case "right":
            validate = col + 1 >= 0 && col + 1 < matrix.GetLength(1) ? "false" : "true";
            col += 1;
            break;
        case "down":
            validate = row + 1 >= 0 && row + 1 < matrix.GetLength(0) ? "false" : "true";
            row += 1;
            break;
    }
    return new string[] { validate, row.ToString(), col.ToString()};
}

void CoalOrExit(int row, int col, string[,] matrix)
{
    if (matrix[row, col] == "c")
    {
        gatheredCoal++;
        if(gatheredCoal == totalCoal)
        {
            Console.WriteLine($"You collected all coals! ({row}, {col})");
            Environment.Exit(0);
        }
    }
    else if (matrix[row, col] == "e")
    {
        Console.WriteLine($"Game over! ({row}, {col})");
        Environment.Exit(0);
    }
}