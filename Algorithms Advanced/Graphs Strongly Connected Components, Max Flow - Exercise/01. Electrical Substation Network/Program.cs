using System;

namespace _01._Electrical_Substation_Network
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            List<int>[] reversedGraph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                int[] nodeArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = nodeArgs[0];
                for (int j = 1; j < nodeArgs.Length; j++)
                {
                    int child = nodeArgs[j];

                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            Stack<int> topologicallySorted = TopologicalSort();

            bool[] visited = new bool[nodes];
            foreach (int node in topologicallySorted)
            {
                Stack<int> component = new Stack<int>();
                if (visited[node])
                {
                    continue;
                }
                DFS(node, reversedGraph, component, visited);

                Console.WriteLine(string.Join(", ", component));
            }

            Stack<int> TopologicalSort()
            {
                Stack<int> result = new Stack<int>();
                bool[] visited = new bool[graph.Length];

                for (int node = 0; node < graph.Length; node++)
                {
                    if (visited[node])
                    {
                        continue;
                    }

                    DFS(node, graph, result, visited);
                }

                return result;
            }

            void DFS(int node, List<int>[] graph, Stack<int> result, bool[] visited)
            {
                if (visited[node])
                {
                    return;
                }

                visited[node] = true;

                foreach (int child in graph[node])
                {
                    DFS(child, graph, result, visited);
                }

                result.Push(node);
            }
        }
    }
}
