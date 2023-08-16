using System;

namespace _01._Black_Friday
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
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            List<Edge> graph = new List<Edge>();
            List<Edge> forest = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int first = edgeArgs[0];
                int second = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(first, second, weight);
                
                graph.Add(edge);
            }

            int[] parents = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                parents[i] = i;
            }

            List<Edge> sortedEdges = graph.OrderBy(edge => edge.Weight).ToList();

            foreach (Edge edge in sortedEdges)
            {
                int firstNodeRoot = FindRoot(edge.First);
                int secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parents[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }

            Console.WriteLine(forest.Sum(edge => edge.Weight));

            int FindRoot(int node)
            {
                while (node != parents[node])
                {
                    node = parents[node];
                }

                return node;
            }
        }
    }
}