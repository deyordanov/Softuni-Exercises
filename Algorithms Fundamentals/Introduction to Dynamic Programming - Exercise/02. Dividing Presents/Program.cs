using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dividing_Presents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = presents.Sum();
            int middle = sum / 2;

            List<int> allanPresents = new List<int>();
            Dictionary<int, int> sums = GetSums();
            while (middle > 0)
            {
                if (!sums.ContainsKey(middle))
                {
                    middle--;
                    continue;
                }

                allanPresents.Add(sums[middle]);
                int num = middle - sums[middle];
                middle = num;
            }

            int allan = allanPresents.Sum();
            int bob = sum - allan;
            Console.WriteLine($"Difference: {bob - allan}");
            Console.WriteLine($"Alan:{allan} Bob:{bob}");
            Console.WriteLine($"Alan takes: {string.Join(" ", allanPresents)}");
            Console.WriteLine($"Bob takes the rest.");

            Dictionary<int, int> GetSums()
            {
                Dictionary<int, int> sums = new Dictionary<int, int>() { {0, 0} };

                foreach (int present in presents)
                {
                    List<int> copy = sums.Keys.ToList();
                    foreach (int sum in copy)
                    {
                        int result = sum + present;
                        if (!sums.ContainsKey(result))
                        {
                            sums.Add(result, present);
                        }
                    }
                }

                return sums;
            }
        }
    }
}
