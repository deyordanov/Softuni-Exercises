using System;

namespace _01._Most_Reliable_Path
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
        private static double[] reliability;
        private static int[] parents;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            reliability = new double[nodes];
            parents = new int[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int first = edgeArgs[0];
                int second = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(first, second, weight);

                graph[first].Add(edge);
                graph[second].Add(edge);
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodes; i++)
            {
                reliability[i] = double.NegativeInfinity;
                parents[i] = -1;
            }

            reliability[source] = 100;

            OrderedBag<int> bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f])));
            bag.Add(source);

            while (bag.Count > 0)
            {
                int minNode = bag.RemoveFirst();

                if (minNode == destination)
                {
                    break;
                }

                if (double.IsNegativeInfinity(reliability[minNode]))
                {
                    break;
                }

                foreach (Edge edge in graph[minNode])
                {
                    int otherNode = minNode == edge.First ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(reliability[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    double currentReliability = (reliability[minNode] * edge.Weight) / 100;

                    if (currentReliability > reliability[otherNode])
                    {
                        reliability[otherNode] = currentReliability;
                        parents[otherNode] = minNode;
                        bag = new OrderedBag<int>(bag,
                            Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f])));
                    }
                }
            }

            Console.WriteLine($"Most reliable path reliability: {reliability[destination]:F2}%");

            Stack<int> path = new Stack<int>();
            int node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = parents[node];   
            }

            Console.WriteLine(string.Join(" -> ", path));
        }
    }
}