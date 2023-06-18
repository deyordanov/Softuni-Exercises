using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Sum_of_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coins = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderByDescending(x => x));
            int target = int.Parse(Console.ReadLine());

            Dictionary<int, int> coinsTaken = new Dictionary<int, int>();
            int coinsCount = 0;

            while (target > 0 && coins.Count > 0)
            {
                int coin = coins.Dequeue();
                int coinsToTake = target / coin;

                if (coinsToTake == 0)
                {
                    continue;
                }

                coinsCount += coinsToTake;
                coinsTaken[coin] = coinsToTake;
                target = target % coin;
            }

            if (target != 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {coinsCount}");
                Console.WriteLine(string.Join(Environment.NewLine, coinsTaken.Select(c => $"{c.Value} coin(s) with value {c.Key}")));
            }
        }
    }
}
