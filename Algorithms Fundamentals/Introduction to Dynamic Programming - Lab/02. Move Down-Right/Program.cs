using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_Down_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int[,] matrix = new int[r, c];
            int[,] sums = new int[r, c];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            sums[0, 0] = matrix[0, 0];
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                sums[0, col] = sums[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                sums[row, 0] = sums[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    sums[row, col] = Math.Max(sums[row - 1, col], sums[row, col - 1]) + matrix[row, col];
                }
            }

            int resRow = sums.GetLength(0) - 1;
            int resCol = sums.GetLength(1) - 1;
            Stack<string> path = new Stack<string>();
            while (resRow > 0 && resCol > 0)
            {
                path.Push($"[{resRow}, {resCol}]");
                if (sums[resRow, resCol - 1] < sums[resRow - 1, resCol])
                {
                    resRow--;
                }
                else
                {
                    resCol--;
                }
            }

            while (resRow > 0)
            {
                path.Push($"[{resRow}, {resCol}]");
                resRow--;
            }

            while (resCol > 0)
            {
                path.Push($"[{resRow}, {resCol}]");
                resCol--;
            }

            path.Push($"[{resRow}, {resCol}]");

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
