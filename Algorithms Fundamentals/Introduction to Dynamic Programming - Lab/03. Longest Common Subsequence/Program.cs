using System;
using System.Collections;
using System.Collections.Generic;

namespace _03._Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first  = Console.ReadLine();
            string second = Console.ReadLine();

            int[,] matrix = new int[first.Length + 1, second.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row, col - 1], matrix[row - 1, col]);
                    }
                }
            }

            Console.WriteLine(matrix[first.Length, second.Length]);

            int r = first.Length;
            int c = second.Length;

            Stack<char> path = new Stack<char>();

            while(r > 0 && c > 0)
            {
                if (first[r - 1] == second[c - 1])
                {
                    path.Push(first[r - 1]);
                    r--;
                    c--;
                }
                else if (matrix[r - 1, c] > matrix[r, c - 1])
                {
                    r--;
                }
                else
                {
                    c--;
                }
            }

            Console.WriteLine(string.Join("", path));
        }
    }
}
