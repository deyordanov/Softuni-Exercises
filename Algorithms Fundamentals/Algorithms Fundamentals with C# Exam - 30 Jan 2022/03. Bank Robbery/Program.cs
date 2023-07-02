using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Bank_Robbery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> loot = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int gold = loot.Sum();
            int goal = gold / 2;

            Dictionary<int ,int> sums = new Dictionary<int ,int>() { {0, 0} };
            foreach (int num in loot)
            {
                List<int> copy = sums.Keys.ToList();
                foreach (int sum in copy)
                {
                    int result = sum + num;
                    if (!sums.ContainsKey(result))
                    {
                        sums.Add(result, num);
                    }
                }
            }

            List<int> firstRobberLoot = new List<int>();
            while (goal > 0)
            {
                if (!sums.ContainsKey(goal))
                {
                    goal--;
                    continue;
                }

                int number = sums[goal];
                firstRobberLoot.Add(number);
                goal -= number;
            }

            Console.WriteLine(string.Join(" ", firstRobberLoot.OrderBy(x => x)));
            Console.WriteLine(string.Join(" ", loot.Where(l => !firstRobberLoot.Contains(l)).OrderBy(x => x)));
        }
    }
}
