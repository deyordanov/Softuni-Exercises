using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Path_Finder
{
    internal class Program
    {
        private static bool[] visited;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (input.Length == 0)
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = input.ToList();
                }
            }

            int paths = int.Parse(Console.ReadLine());
            for (int i = 0; i < paths; i++)
            {
                bool isPath = true;
                List<int> input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                int index = 1;
                while (index < input.Count())
                {
                    if (!graph[input[index - 1]].Contains(input[index]))
                    {
                        isPath = false;
                        break;
                    }

                    index++;
                }

                Console.WriteLine(isPath ? "yes" : "no");
            }
        }
    }
}
