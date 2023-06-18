namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];
            int pRow = 0;
            int pCol = 0;
            int opponentsCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbols[col] == "B")
                    {
                        symbols[col] = "-";
                        pRow = row;
                        pCol = col;
                    }
                    else if (symbols[col] == "P")
                    {
                        opponentsCount++;
                    }
                    matrix[row, col] = symbols[col];
                }
            }

            string end;
            int movesMade = 0;
            int opponentsTouched = 0;
            while ((end = Console.ReadLine()) != "Finish" && opponentsTouched < opponentsCount)
            {
                string direction = end;
                switch (direction)
                {
                    case "up":
                        if (!Check(pRow - 1, pCol))
                        {
                            pRow--;
                            WhereAmI(pRow, pCol);
                        }
                        break;
                    case "right":
                        if (!Check(pRow, pCol + 1))
                        {
                            pCol++;
                            WhereAmI(pRow, pCol);
                        }
                        break;
                    case "down":
                        if (!Check(pRow + 1, pCol))
                        {
                            pRow++;
                            WhereAmI(pRow, pCol);
                        }
                        break;
                    case "left":
                        if (!Check(pRow, pCol - 1))
                        {
                            pCol--;
                            WhereAmI(pRow, pCol);
                        }
                        break;
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {movesMade}");

            void WhereAmI(int row, int col)
            {
                string symbol = matrix[row, col];
                if (symbol == "P")
                {
                    opponentsTouched++;
                    matrix[row, col] = "-";
                }
                movesMade++;
            }

            bool Check(int row, int col)
            {
                if (row < 0 || row >= matrix.GetLength(0) || col < 0  || col >= matrix.GetLength(1) || matrix[row, col] == "O")
                {
                    return true;
                }
                return false;
            }
        }
    }
}