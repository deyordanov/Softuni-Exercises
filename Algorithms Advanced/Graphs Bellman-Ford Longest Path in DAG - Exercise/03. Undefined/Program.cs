using System;

namespace _03._Undefined
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
        private static int[] prev;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeArgs[0];
                int to = edgeArgs[1];
                int weight = edgeArgs[2];

                graph.Add(new Edge(from, to, weight));
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            prev = new int[nodes + 1];

            for (int i = 0; i <= nodes; i++)
            {
                distance[i] = double.PositiveInfinity;
                prev[i] = -1;
            }

            distance[source] = 0;

            for (int i = 0; i < nodes - 2; i++)
            {
                foreach (Edge edge in graph)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    double currentDistance = distance[edge.From] + edge.Weight;

                    if (currentDistance < distance[edge.To])
                    {
                        distance[edge.To] = currentDistance;
                        prev[edge.To] = edge.From;
                    }
                }
            }

            foreach (Edge edge in graph)
            {
                double currentDistance = distance[edge.From] + edge.Weight;
                if (currentDistance < distance[edge.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            Stack<int> path = new Stack<int>();
            int currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}