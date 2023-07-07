using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Paths
{
    internal class Program
    {
        private static List<int> elements;
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

                if (input == null)
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = input.ToList();
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                elements = new List<int>();
                visited = new bool[nodes];
                DFS(i);
            }

            void DFS(int node)
            {
                if (visited[node])
                {
                    return;
                }

                visited[node] = true;
                elements.Add(node);

                foreach (int child in graph[node])
                {
                    DFS(child);
                }

                if (node == nodes - 1 && elements[0] != nodes - 1)
                {
                    Console.WriteLine(string.Join(" ", elements));
                }

                elements.Remove(node);
                visited[node] = false;
            }
        }
    }
}
