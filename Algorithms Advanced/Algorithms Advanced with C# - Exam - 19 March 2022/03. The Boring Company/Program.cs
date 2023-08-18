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
        private static List<Edge>[] graph;
        private static HashSet<int> forestNodes;
        private static List<Edge> forestEdges;

        static void Main(string[] args)
        {
            forestNodes = new HashSet<int>();
            forestEdges = new List<Edge>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            int alreadyConnected = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(firstNode, secondNode, weight);

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            for (int i = 0; i < alreadyConnected; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];

                forestNodes.Add(firstNode);
                forestNodes.Add(secondNode);
            }

            Console.WriteLine($"Minimum budget: {Prim()}");
        }

        private static int Prim()
        {
            OrderedBag<Edge> priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            foreach (int node in forestNodes)
            {
                priorityQueue.AddMany(graph[node]);
            }

            int budgedUsed = 0;
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

                budgedUsed += minEdge.Weight;
                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);
                priorityQueue.AddMany(graph[nonTreeNode]);
            }

            return budgedUsed;
        }
    }
}