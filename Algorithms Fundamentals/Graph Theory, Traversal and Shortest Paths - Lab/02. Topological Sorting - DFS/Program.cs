using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Topological_Sorting___DFS
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycle;
        private static LinkedList<string> sorted;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycle = new HashSet<string>();
            sorted = new LinkedList<string>();

            int n = int.Parse(Console.ReadLine());
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

            foreach (string node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    return;
                }
            }

            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        public static void DFS(string node)
        {
            if (cycle.Contains(node))
            {
                throw new InvalidOperationException("Invalid graph - contains a cycle!");
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycle.Add(node);

            foreach (string child in graph[node])
            {
                DFS(child);
            }

            cycle.Remove(node);
            sorted.AddFirst(node);
        }
    }
}
