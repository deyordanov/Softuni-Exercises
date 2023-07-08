using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] nums2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[nums1.Length + 1, nums2.Length + 1];

            Dictionary<string, int> seq = new Dictionary<string, int>();

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (nums1[row - 1] == nums2[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            int r = nums1.Length;
            int c = nums2.Length;
            Stack<int> path = new Stack<int>();
            while (r > 0 && c > 0)
            {
                if (nums1[r - 1] == nums2[c - 1])
                {
                    path.Push(nums1[r - 1]);
                    r--;
                    c--;
                }
                else if (matrix[r, c - 1] >= matrix[r - 1, c])
                {
                    c--;
                }
                else
                {
                    r--;
                }
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(matrix[nums1.Length, nums2.Length]);
        }
    }
}
