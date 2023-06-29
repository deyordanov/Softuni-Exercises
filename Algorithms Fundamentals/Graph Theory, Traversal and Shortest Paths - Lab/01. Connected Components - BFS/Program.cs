using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components___BFS
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];
            for (int node = 0; node < n; node++)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    graph[node] = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node] == true)
                {
                    continue;
                }
                List<int> components = new List<int>();
                BFS(node, components);
                Console.WriteLine($"Connected component: {string.Join(" ", components)}");
            }
        }

        private static void BFS(int startNode, List<int> components)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                components.Add(node);

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);   
                    }
                }
            }
        }
    }
}
