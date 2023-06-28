using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Topological_Sorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> predecessorsCount;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            predecessorsCount = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                if (input.Length == 1)
                {
                    graph[input[0]] = new List<string>();
                }
                else
                {
                    graph[input[0]] = input[1].Split(", ").ToList();
                }
            }

            GetPredecessors();

            List<string> sorted = new List<string>();
            while (predecessorsCount.Count() > 0)
            {
                string nodeToRemove = predecessorsCount.Where(x => x.Value == 0).FirstOrDefault().Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                foreach (string child in graph[nodeToRemove])
                {
                    predecessorsCount[child]--;
                }

                sorted.Add(nodeToRemove);
                predecessorsCount.Remove(nodeToRemove);
            }

            if (predecessorsCount.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
        }

        public static void GetPredecessors()
        {
            foreach (var node in graph)
            {
                if (!predecessorsCount.ContainsKey(node.Key))
                {
                    predecessorsCount[node.Key] = 0;
                }

                foreach (string child in node.Value)
                {
                    if (!predecessorsCount.ContainsKey(child))
                    {
                        predecessorsCount[child] = 0;
                    }

                    predecessorsCount[child]++;
                }
            }
        }
    }
}