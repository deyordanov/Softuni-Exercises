using System;

namespace _01._Move_Down___Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size1 = int.Parse(Console.ReadLine());
            int size2 = int.Parse(Console.ReadLine());
            long[,] matrix = new long[size1 + 1, size2 + 1];
            matrix[1, 0] = 1;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrix[row - 1, col] + matrix[row, col - 1];
                }
            }

            Console.WriteLine(matrix[size1, size2]);
        }
    }
}