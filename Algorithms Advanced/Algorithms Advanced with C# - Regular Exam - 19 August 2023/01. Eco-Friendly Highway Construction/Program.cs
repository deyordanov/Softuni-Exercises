namespace _01.First
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public Edge(string first, string second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge> edges;
        private static List<Edge> forest;
        private static Dictionary<string, string> prev;
        static void Main(string[] args)
        {
            edges = new List<Edge>();
            forest = new List<Edge>();
            prev = new Dictionary<string, string>();

            int edgeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < edgeCount; i++)
            {
                string[] edgeArgs = Console.ReadLine().Split();

                string first = edgeArgs[0];
                string second = edgeArgs[1];
                int cost = int.Parse(edgeArgs[2]);
                int envCost = edgeArgs.Length > 3 ? int.Parse(edgeArgs[3]) : 0;

                if (!prev.ContainsKey(first))
                {
                    prev.Add(first, first);
                }

                if (!prev.ContainsKey(second))
                {
                    prev.Add(second, second);
                }

                Edge edge = new Edge(first, second, cost + envCost);
                edges.Add(edge);
            }

            edges = edges.OrderBy(e => e.Weight).ToList();

            foreach (Edge edge in edges)
            {
                string firstNodeRoot = FindRoot(edge.First);
                string secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                forest.Add(edge);
                prev[firstNodeRoot] = secondNodeRoot;
            }

            int totalCost = 0;
            foreach (Edge edge in forest)
            {
                totalCost += edge.Weight;
            }

            Console.WriteLine($"Total cost of building highways: {totalCost}");

            string FindRoot(string node)
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