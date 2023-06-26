using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_with_Limited_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSums());

            int GetSums()
            {
                int counter = 0;
                HashSet<int> sums = new HashSet<int>() { 0 };

                foreach (int number in numbers)
                {
                    HashSet<int> currSums = new HashSet<int>();
                    foreach (int sum in sums)
                    {
                        int result = number + sum;
                        currSums.Add(result);
                        if (result == target)
                        {
                            counter++;
                        }
                    }
                    sums.UnionWith(currSums);
                }

                return counter;
            }
        }
    }
}
