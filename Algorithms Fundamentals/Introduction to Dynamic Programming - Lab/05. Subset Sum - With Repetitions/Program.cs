using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Subset_Sum___With_Repetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int target = 16;

            bool[] sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (!sums[sum])
                {
                    continue;
                }

                foreach (int number in numbers)
                {
                    int newSum = sum + number;

                    if (newSum > target)
                    {
                        continue;
                    }

                    sums[newSum] = true;
                }
            }

            List<int> subset = new List<int>();
            while (target > 0)
            {
                foreach (int number in numbers)
                {
                    int prevSum = target - number;
                    if (prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(number);
                        target = prevSum;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", subset));
        }
    }
}
