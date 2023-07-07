using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Climbing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int[,] matrix = new int[r, c];
            int[,] copy = new int[r, c];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            copy[0, 0] = matrix[0, 0];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                copy[row, 0] = copy[row - 1, 0] + matrix[row, 0];
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                copy[0, col] = copy[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    copy[row, col] = Math.Max(copy[row - 1, col], copy[row, col - 1]) + matrix[row, col];
                }
            }

            int pRow = copy.GetLength(0) - 1;
            int pCol = copy.GetLength(1) - 1;
            List<int> path = new List<int>() { matrix[pRow, pCol] };
            while (pRow > 0 && pCol > 0)
            {
                if (copy[pRow, pCol - 1] >= copy[pRow - 1, pCol])
                {
                    path.Add(matrix[pRow, pCol - 1]);
                    pCol--;
                }
                else
                {
                    path.Add(matrix[pRow - 1, pCol]);
                    pRow--;
                }
            }

            while (pCol > 0)
            {
                path.Add(matrix[pRow, pCol - 1]);
                pCol--;
            }

            while (pRow > 0)
            {
                path.Add(matrix[pRow - 1, pCol]);
                pRow--;
            }

            Console.WriteLine(path.Sum());
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
