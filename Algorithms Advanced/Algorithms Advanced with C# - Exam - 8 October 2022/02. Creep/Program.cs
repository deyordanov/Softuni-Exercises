namespace _02._Creep
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        private static List<Edge> edges;
        private static List<Edge> forest;
        private static int[] parent;
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            int nodes = int.Parse(Console.ReadLine()) + 1;
            int zones = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < zones; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge remove = graph[firstNode].FirstOrDefault(e => e.First == firstNode && e.Second == secondNode);

                if (remove != null)
                {
                    remove.Weight = weight;
                    continue;
                }

                Edge edge = new Edge(firstNode, secondNode, weight);

                edges.Add(edge);
                graph[firstNode].Add(edge);
            }

            parent = new int[nodes];

            for (int node = 0; node < nodes; node++)
            {
                parent[node] = node;
            }

            List<Edge> sortedEdges = edges.OrderBy(e => e.Weight).ToList();

            foreach (Edge edge in sortedEdges)
            {
                int firstNodeRoot = FindRoot(edge.First);
                int secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[secondNodeRoot] = firstNodeRoot;
                forest.Add(edge);
            }

            int length = 0;
            foreach (Edge edge in forest)
            {
                Console.WriteLine($"{edge.First} {edge.Second}");
                length += edge.Weight;
            }
            Console.WriteLine(length);

            int FindRoot(int node)
            {
                while (node != parent[node])
                {
                    node = parent[node];
                }

                return node;
            }
        }
    }
}