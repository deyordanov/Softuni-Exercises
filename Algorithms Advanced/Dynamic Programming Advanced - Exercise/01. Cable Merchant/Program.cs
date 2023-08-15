using System;

namespace _01._Cable_Merchant
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cable = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int connectorPrice = int.Parse(Console.ReadLine());

            int[] memoization = new int[cable.Length + 1];
            List<int> prices = new List<int>();

            CutCable(cable.Length);

            Console.WriteLine(string.Join(" ", prices));

            int CutCable(int length)
            {
                if (memoization[length] != 0)
                {
                    return memoization[length];
                }

                int bestPrice = cable[length - 1];

                for (int i = 1; i < length; i++)
                {
                    int currentPrice = cable[i - 1] + CutCable(length - i);

                    if (currentPrice - (2 * connectorPrice) > bestPrice)
                    {
                        bestPrice = currentPrice - (2 * connectorPrice);
                    }
                }

                memoization[length] = bestPrice;
                prices.Add(bestPrice);

                return bestPrice;
            }
        }
    }
}
