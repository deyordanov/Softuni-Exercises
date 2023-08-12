using System;

namespace _04._Big_Trip
{
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;
        private static double[] distance;
        private static int[] prev;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes + 1];
            for (int i = 0; i <= nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeArgs[0];
                int to = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(from, to, weight);

                graph[from].Add(edge);
                graph[to].Add(edge);
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            prev = new int[nodes + 1];

            for (int i = 0; i <= nodes; i++)
            {
                distance[i] = double.NegativeInfinity;
                prev[i] = -1;
            }

            distance[source] = 0;

            Stack<int> topologicallySortedNodes = TopologicalSort();

            while (topologicallySortedNodes.Count > 0)
            {
                int node = topologicallySortedNodes.Pop();

                foreach (Edge edge in graph[node])
                {
                    double currentDistance = distance[edge.From] + edge.Weight;

                    if (distance[edge.To] < currentDistance)
                    {
                        distance[edge.To] = currentDistance;
                        prev[edge.To] = edge.From;
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(distance[destination]);
            Console.WriteLine(string.Join(" ", path));

            Stack<int> TopologicalSort()
            {
                Stack<int> result = new Stack<int>();
                bool[] visited = new bool[nodes + 1];

                DFS(source, visited, result);

                return result;
            }

            void DFS(int node, bool[] visited, Stack<int> result)
            {
                if (visited[node])
                {
                    return;
                }

                visited[node] = true;

                foreach (Edge edge in graph[node])
                {
                    DFS(edge.To, visited, result);
                }

                result.Push(node);
            }
        }
    }
}