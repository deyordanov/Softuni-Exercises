using System;

namespace _01._Bellman_Ford
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
        private static List<Edge> graph;
        private static double[] distance;
        private static int[] parents;
        static void Main(string[] args)
        {
            graph = new List<Edge>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge(edgeArgs[0], edgeArgs[1], edgeArgs[2]));
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);
            distance[source] = 0;

            parents = new int[nodes + 1];
            Array.Fill(parents, -1);

            for (int i = 0; i < nodes - 1; i++)
            {
                bool updated = false;

                foreach (Edge edge in graph)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    double newDistance = distance[edge.From] + edge.Weight;
                    if (distance[edge.To] > newDistance)
                    {
                        updated = true;
                        parents[edge.To] = edge.From;
                        distance[edge.To] = newDistance;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (Edge edge in graph)
            {
                double newDistance = distance[edge.From] + edge.Weight;
                if (distance[edge.To] > newDistance)
                {
                      Console.WriteLine("Negative Cycle Detected");
                      return;
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
        }
    }
}