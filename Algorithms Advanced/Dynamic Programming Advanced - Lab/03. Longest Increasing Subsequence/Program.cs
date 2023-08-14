using System;

namespace _03._Longest_Increasing_Subsequence
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] length = new int[sequence.Length];
            int[] prev = new int[sequence.Length];

            int maxLength = 0;
            int lastIdx = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                int bestLength = 1;
                int parentIndex = -1;

                int currentNumber = sequence[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    int previousNumber = sequence[j];

                    if (currentNumber > previousNumber &&
                        bestLength <= length[j] + 1)
                    {
                        bestLength = length[j] + 1;
                        parentIndex = j;
                    }
                }

                length[i] = bestLength;
                prev[i] = parentIndex;

                if (bestLength > maxLength)
                {
                    maxLength = bestLength;
                    lastIdx = i;
                }
            }

            Stack<int> result = new Stack<int>();
            while (lastIdx != -1)
            {
                result.Push(sequence[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
