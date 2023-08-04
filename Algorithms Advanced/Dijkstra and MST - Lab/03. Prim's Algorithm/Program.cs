using System;

namespace _03._Prim_s_Algorithm
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public Edge(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static List<int> forestNodes;
        private static List<Edge> forestEdges;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();
            forestNodes = new List<int>();
            forestEdges = new List<Edge>();

            int countOfEdges = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(firstNode, secondNode, weight);

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<Edge>();
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<Edge>();
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            foreach(int node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                {
                    Prim(node);
                }
            }

            foreach (Edge edge in forestEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static void Prim(int node)
        {
            forestNodes.Add(node);

            OrderedBag<Edge> priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            priorityQueue.AddMany(graph[node]);

            while (priorityQueue.Count > 0)
            {
                Edge minEdge = priorityQueue.RemoveFirst();

                int nonTreeNode = -1;

                if (forestNodes.Contains(minEdge.First) &&
                    !forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (!forestNodes.Contains(minEdge.First) &&
                    forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);
                priorityQueue.AddMany(graph[nonTreeNode]);
            }
        }
    }
}