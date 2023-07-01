using System;
using System.Collections.Generic;

namespace _03._Cycles_in_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            HashSet<string> cycle = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();

            string end;
            while ((end = Console.ReadLine()) != "End")
            {
                string[] input = end.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (!graph.ContainsKey(input[0]))
                {
                    graph.Add(input[0], new List<string>());
                }

                if (!graph.ContainsKey(input[1]))
                {
                    graph.Add(input[1], new List<string>());
                }
                graph[input[0]].Add(input[1]);
            }

            foreach (var node in graph)
            {
                try
                {
                    DFS(node.Key);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");

            void DFS(string node)
            {
                if (cycle.Contains(node))
                {
                    throw new InvalidOperationException("Acyclic: No");
                }

                if (visited.Contains(node))
                {
                    return;
                }

                visited.Add(node);

                foreach (string child in graph[node])
                {
                    cycle.Add(node);
                    DFS(child);
                    cycle.Remove(node);
                }

            }
        }
    }
}
