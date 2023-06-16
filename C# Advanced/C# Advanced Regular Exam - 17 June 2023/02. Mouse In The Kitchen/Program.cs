namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            int mRow = 0;
            int mCol = 0;
            int cheese = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbols[col] == 'M')
                    {
                        mRow = row;
                        mCol = col;
                        symbols[col] = '*';
                    }
                    else if (symbols[col] == 'C')
                    {
                        cheese++;
                    }
                    matrix[row, col] = symbols[col];
                }
            }

            string end;
            int cheeseEaten = 0;
            while ((end = Console.ReadLine()) != "danger")
            {
                string direction = end;
                switch (direction)
                {
                    case "up":
                        HaveIBeenEaten(mRow - 1, mCol);
                        if (CanIMove(mRow - 1, mCol))
                        {
                            mRow--;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "right":
                        HaveIBeenEaten(mRow, mCol + 1);
                        if (CanIMove(mRow, mCol + 1))
                        {
                            mCol++;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "down":
                        HaveIBeenEaten(mRow + 1, mCol);
                        if (CanIMove(mRow + 1, mCol))
                        {
                            mRow++;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "left":
                        HaveIBeenEaten(mRow, mCol - 1);
                        if (CanIMove(mRow, mCol - 1))
                        {
                            mCol--;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                }
            }

            Console.WriteLine("Mouse will come back later!");
            PrintMatrix();

            void WhereAmI(int row, int col)
            {
                char symbol = matrix[row, col];
                if (symbol == 'C')
                {
                    matrix[row, col] = '*';
                    cheeseEaten++;
                    if (cheeseEaten == cheese)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        PrintMatrix();
                        Environment.Exit(0);
                    }
                }
                else if (symbol == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix();
                    Environment.Exit(0);
                }
            }

            bool CanIMove(int row, int col)
            {
                if (matrix[row, col] == '@')
                {
                    return false;
                }
                return true;
            }

            void HaveIBeenEaten(int row , int col)
            {
                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix();
                    Environment.Exit(0);
                }
            }

            void PrintMatrix()
            {
                matrix[mRow, mCol] = 'M';
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}