using System;

namespace _03._Code
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] seq1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] seq2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] table = new int[seq1.Length + 1, seq2.Length + 1];

            for (int row = 1; row <= seq1.Length; row++)
            {
                for (int col = 1; col <= seq2.Length; col++)
                {
                    if (seq1[row - 1] == seq2[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        table[row, col] = Math.Max(table[row - 1, col], table[row, col - 1]);
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int r = seq1.Length;
            int c = seq2.Length;
            while (r > 0 && c > 0)
            {
                if (seq1[r - 1] == seq2[c - 1])
                {
                    path.Push(seq1[r - 1]);
                    r--;
                    c--;
                }
                else if (table[r - 1, c] > table[r, c - 1])
                {
                    r--;
                }
                else
                {
                    c--;
                }
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(path.Count);
        }
    }
}
