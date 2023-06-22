using System;
using System.Collections.Generic;
using System.Linq;

namespace Subset_Sum___No_Repetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int target = 6;
            Dictionary<int, int> sums = GetSums();

            while (target > 0)
            {
                int number = sums[target];
                Console.WriteLine(number);
                target -= number;
            }

            Dictionary<int, int> GetSums()
            {
                Dictionary<int, int> sums = new Dictionary<int, int>() { {0, 0} };

                foreach (int number in numbers)
                {
                    List<int> newSums = sums.Keys.ToList();
                    foreach (int sum in newSums)
                    {
                        int result = number + sum;
                        if (!sums.ContainsKey(result))
                        {
                            sums.Add(result, number);
                            if (result == target)
                            {
                                return sums;
                            }
                        }
                    }
                }

                return sums;
            }


        }
    }
}
