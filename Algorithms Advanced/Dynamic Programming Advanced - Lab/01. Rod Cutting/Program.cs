using System;

namespace _01._Rod_Cutting
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] memoization = new int[prices.Length];
            int[] prev = new int[prices.Length];

            int size = int.Parse(Console.ReadLine());

            Console.WriteLine(CutRod(size));

            List<int> result = new List<int>();
            while (size != 0)
            {
                result.Add(prev[size]);
                size = size - prev[size];
            }

            Console.WriteLine(string.Join(" ", result));

            int CutRod(int length)
            {
                if (memoization[length] != 0)
                {
                    return memoization[length];
                }

                int bestPrice = prices[length];
                int bestCombo = length;

                for (int i = 1; i < length; i++)
                {
                    int currentPrice = prices[i] + CutRod(length - i);

                    if (currentPrice > bestPrice)
                    {
                        bestPrice = currentPrice;
                        bestCombo = i;
                    }
                }

                memoization[length] = bestPrice;
                prev[length] = bestCombo;

                return bestPrice;
            }
        }
    }
}
