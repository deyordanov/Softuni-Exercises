namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int sRow = -1;
            int sCol = -1;
            string[] directions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbols[col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                    matrix[row, col] = symbols[col];
                }
            }

            int hazelnuts = 0;
            for(int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i];
                switch (direction)
                {
                    case "up":
                        sRow--;
                        WhatDidIStepOn(sRow, sCol);
                        break;
                    case "right":
                        sCol++;
                        WhatDidIStepOn(sRow, sCol);
                        break;
                    case "down":
                        sRow++;
                        WhatDidIStepOn(sRow, sCol);
                        break;
                    case "left":
                        sCol--;
                        WhatDidIStepOn(sRow, sCol);
                        break;
                }
            }

            Console.WriteLine("There are more hazelnuts to collect.");
            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");

            void WhatDidIStepOn(int row, int col)
            {
                if(row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix.GetLength(1))
                {
                    char symbol = matrix[row, col];
                    if (symbol == 'h')
                    {
                        matrix[row, col] = '*';
                        ++hazelnuts;
                        if(hazelnuts == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                    }
                    else if (symbol == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                    Environment.Exit(0);
                }
                
            }
        }
    }
}