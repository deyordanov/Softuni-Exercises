using System;

namespace _02._Kruskal_s_Algorithm
{
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

        static void Main(string[] args)
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            int countOfEdges = int.Parse(Console.ReadLine());
            int maxNode = -1;

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }

                if (secondNode > maxNode)
                {
                    maxNode = secondNode;
                }

                edges.Add(new Edge(firstNode, secondNode, weight));
            }

            parent = new int[maxNode + 1];

            for (int node = 0; node < parent.Length; node++)
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

                parent[firstNodeRoot] = secondNodeRoot;   
                forest.Add(edge);
            }

            foreach (Edge edge in forest)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }

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