using System;
using System.Collections.Generic;

namespace Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int mRow = -1;
            int mCol = -1;
            List<int> holeCoords = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbols[col] == 'M')
                    {
                        symbols[col] = '-';
                        mRow = row;
                        mCol = col;
                    }
                    else if (symbols[col] == 'S')
                    {
                        holeCoords.Add(row);
                        holeCoords.Add(col);
                    }
                    matrix[row, col] = symbols[col];
                }
            }

            string end;
            int score = 0;
            while ((end = Console.ReadLine()) != "End")
            {
                string direction = end;
                switch (direction)
                {
                    case "up":
                        if (!IsOut(mRow - 1, mCol))
                        {
                            mRow--;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "right":
                        if (!IsOut(mRow, mCol + 1))
                        {
                            mCol++;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "down":
                        if (!IsOut(mRow + 1, mCol))
                        {
                            mRow++;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                    case "left":
                        if (!IsOut(mRow, mCol - 1))
                        {
                            mCol--;
                            WhereAmI(mRow, mCol);
                        }
                        break;
                }
            }


            Console.WriteLine("Too bad! The Mole lost this battle!");
            Console.WriteLine($"The Mole lost the game with a total of {score} points.");
            PrintMatrix();

            void WhereAmI(int row, int col)
            {
                char symbol = matrix[row, col];
                if (char.IsDigit(symbol))
                {
                    score += symbol - '0';
                    matrix[row, col] = '-';
                    if (score >= 25)
                    {
                        Console.WriteLine("Yay! The Mole survived another game!");
                        Console.WriteLine($"The Mole managed to survive with a total of {score} points.");
                        PrintMatrix();
                        Environment.Exit(0);
                    }
                }
                else if (symbol == 'S')
                {
                    holeCoords.Remove(row);
                    holeCoords.Remove(col);
                    matrix[row, col] = '-';
                    matrix[holeCoords[0], holeCoords[1]] = '-';
                    mRow = holeCoords[0];
                    mCol = holeCoords[1];
                    score -= 3;
                }
            }

            bool IsOut(int row, int col)
            {
                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    return true;
                }
                return false;
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
