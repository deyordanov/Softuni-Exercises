using System;

namespace _02._Cheap_Town_Tour
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
        private static int[] prev;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            edges = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                int first = edgeArgs[0];
                int second = edgeArgs[1];
                int weight = edgeArgs[2];

                edges.Add(new Edge(first, second, weight));
            }

            prev = new int[nodes];

            for (int i = 0; i < nodes; i++)
            {
                prev[i] = i;
            }

            List<Edge> sortedEdges = edges.OrderBy(edge => edge.Weight).ToList();

            int cost = 0;
            foreach (Edge edge in sortedEdges)
            {
                int firstRoot = FindRoot(edge.First);
                int secondRoot = FindRoot(edge.Second);

                if (firstRoot == secondRoot)
                {
                    continue;
                }

                cost += edge.Weight;
                prev[firstRoot] = secondRoot;
            }

            Console.WriteLine($"Total cost: {cost}");

            int FindRoot(int node)
            {
                while (node != prev[node])
                {
                    node = prev[node];
                }

                return node;
            }
        }
    }
}