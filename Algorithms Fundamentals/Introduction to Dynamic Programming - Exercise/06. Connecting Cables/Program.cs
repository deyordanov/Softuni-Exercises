using System;
using System.Linq;

namespace _06._Connecting_Cables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] orderedNums = Enumerable.Range(1, nums.Length).ToArray();

            int[,] matrix = new int[nums.Length + 1, nums.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (nums[row - 1] == orderedNums[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {matrix[nums.Length, nums.Length]}");
        }
    }
}
