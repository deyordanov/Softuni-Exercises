using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[n];
            bool[] visited = new bool[graph.Length];

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
                DFS(node, components);
                Console.WriteLine($"Connected component: {string.Join(" ", components)}");
            }

            void DFS(int node, List<int> components)
            {
                if (visited[node] == true)
                {
                    return;
                }

                visited[node] = true;

                foreach (var child in graph[node])
                {
                    DFS(child, components);
                }

                components.Add(node);
            }

        }
    }
}
