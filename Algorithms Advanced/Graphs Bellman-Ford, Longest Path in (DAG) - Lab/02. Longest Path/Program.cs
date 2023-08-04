using System;

namespace _02._Longest_Path
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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parents;
        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeArgs[0];
                int to = edgeArgs[1];
                int weight = edgeArgs[2];

                if (!edgesByNode.ContainsKey(from))
                {
                    edgesByNode.Add(from, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(to))
                {
                    edgesByNode.Add(to, new List<Edge>());
                }

                edgesByNode[from].Add(new Edge(from, to, weight));
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);
            distance[source] = 0;

            parents = new int[nodes + 1];
            Array.Fill(parents, -1);

            Stack<int> sortedNodes = TopologicalSorting();

            while (sortedNodes.Count > 0)
            {
                int node = sortedNodes.Pop();

                foreach (Edge edge in edgesByNode[node])
                {
                    double currentDistance = distance[edge.From] + edge.Weight;

                    if (currentDistance > distance[edge.To])
                    {
                        parents[edge.To] = edge.From;
                        distance[edge.To] = currentDistance;
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parents[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);

            Stack<int> TopologicalSorting()
            {
                Stack<int> result = new Stack<int>();
                HashSet<int> visited = new HashSet<int>();

                foreach (int node in edgesByNode.Keys)
                {
                    DFS(node, visited, result);
                }


                return result;
            }
        }

        private static void DFS(int node, HashSet<int> visited, Stack<int> result)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (Edge edge in edgesByNode[node])
            {
                DFS(edge.To, visited, result);
            }

            result.Push(node);
        }
    }
}