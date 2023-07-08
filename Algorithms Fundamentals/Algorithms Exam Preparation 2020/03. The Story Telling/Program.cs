using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string end;
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            HashSet<string> visited = new HashSet<string>();
            while ((end = Console.ReadLine()) != "End")
            {
                string[] input = end
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                if (!graph.ContainsKey(input[0]))
                {
                    if (input.Length == 1)
                    {
                        graph.Add(input[0], new List<string>());
                    }
                    else if (input.Length == 2)
                    {
                        graph.Add(input[0], input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
                    }
                }
            }

            Stack<string> path = new Stack<string>();
            foreach (var node in graph)
            {
                if (!visited.Contains(node.Key))
                {
                    DFS(node.Key);
                }
            }

            Console.WriteLine(string.Join(" ", path));

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

                path.Push(node);
            }
        }
    }
}
