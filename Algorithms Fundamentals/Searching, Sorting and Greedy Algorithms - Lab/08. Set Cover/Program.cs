using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Set_Cover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> universe = new HashSet<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int n = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] set  = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sets.Add(set);  
            }

            List<int[]> selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] set = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).FirstOrDefault();

                selectedSets.Add(set);

                sets.Remove(set);

                foreach (int element in set)
                {
                    universe.Remove(element);   
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count()}):");
            foreach (int[] set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
