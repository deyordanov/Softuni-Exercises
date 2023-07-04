using System;
using System.Collections.Generic;

namespace _02._Universes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            HashSet<string> visited = new HashSet<string>();
            for (int i = 0; i < nodes; i++)
            {
                string[] input = Console.ReadLine().Split(" - ");
                if (!graph.ContainsKey(input[0]))
                {
                    graph.Add(input[0], new List<string>());
                }

                if (!graph.ContainsKey(input[1]))
                {
                    graph.Add(input[1], new List<string>());
                }

                graph[input[1]].Add(input[0]);
                graph[input[0]].Add(input[1]);
            }

            int universes = 0;
            foreach (string node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node);
                    universes++;
                }
            }

            Console.WriteLine(universes);

            void DFS(string node)
            {
                if (visited.Contains(node))
                {
                    return;
                }

                visited.Add(node);

                foreach (string child in graph[node])
                {
                    DFS(child);
                }
            }
        }
    }
}