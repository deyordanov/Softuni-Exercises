using System;

namespace _04._Longest_Zigzag_Subsequence
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[,] table = new int[2, sequence.Length];
            table[0, 0] = table[1, 0] = 1;

            int[,] parents = new int[2, sequence.Length];
            parents[0, 0] = parents[1, 0] = -1;

            int maxLength = 0;
            int lastRow = 0;
            int lastCol = 0;
            for (int current = 1; current < sequence.Length; current++)
            {
                int currentNumber = sequence[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    int previousNumber = sequence[prev];

                    if (currentNumber > previousNumber && table[1, prev] + 1 >= table[0, current])
                    {
                        table[0, current] = table[1, prev] + 1;
                        parents[0, current] = prev;
                    }

                    if (currentNumber < previousNumber && table[0, prev] + 1 >= table[1, current])
                    {
                        table[1, current] = table[0, prev] + 1;
                        parents[1, current] = prev;
                    }
                }

                if (table[0, current] > maxLength)
                {
                    maxLength = table[0, current];
                    lastRow = 0;
                    lastCol = current;
                }

                if (table[1, current] > maxLength)
                {
                    maxLength = table[1, current];
                    lastRow = 1;
                    lastCol = current;
                }
            }

            Stack<int> result = new Stack<int>();
            while (lastCol != -1)
            {
                result.Push(sequence[lastCol]);
                lastCol = parents[lastRow, lastCol];
                lastRow = lastRow == 0 ? 1 : 0;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
