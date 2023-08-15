using System;

namespace _03._Longest_String_Chain
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ");

            int[] length = new int[strings.Length];
            int[] prev = new int[strings.Length];
            Array.Fill(prev, -1);

            int maxLength = 0;
            int lastIdx = -1;
            for (int i = 0; i < strings.Length; i++)
            {
                int currentLength = strings[i].Length;

                int bestLength = 1;
                int prevIdx = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    int previousLength = strings[j].Length;

                    if (currentLength > previousLength &&
                        bestLength <= length[j] + 1)
                    {
                        bestLength = length[j] + 1;
                        prevIdx = j;
                    }
                }

                length[i] = bestLength;
                prev[i] = prevIdx;

                if (maxLength < bestLength)
                {
                    maxLength = bestLength;
                    lastIdx = i;
                }
            }

            Stack<string> result = new Stack<string>();
            while (lastIdx != -1)
            {
                result.Push(strings[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
