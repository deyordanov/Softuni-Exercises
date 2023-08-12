using System;

namespace _01._Strongly_Connected_Components
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
                reversedGraph[i] = new List<int>();
                graph[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                int[] inputArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = inputArgs[0];

                for (int j = 1; j < inputArgs.Length; j++)
                {
                    int child = inputArgs[j];

                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            Stack<int> topologicallySorted = TopologicalSort(graph);

            bool[] visited = new bool[nodes];
            Console.WriteLine("Strongly Connected Components:");
            while(topologicallySorted.Count > 0)
            {
                int node = topologicallySorted.Pop();

                Stack<int> component = new Stack<int>();

                if (visited[node])
                {
                    continue;
                }

                DFS(node, reversedGraph, component, visited);

                Console.WriteLine($"{{{string.Join(", ", component)}}}");
            }

            Stack<int> TopologicalSort(List<int>[] graph)
            {
                Stack<int> result = new Stack<int>();
                bool[] visited = new bool[graph.Length];

                for (int node = 0; node < graph.Length; node++)
                {
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
