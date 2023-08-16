using System;

namespace _02._Robbery
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
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            List<Edge>[] graph = new List<Edge>[nodes];
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

            string[] cameras = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<int> forbidden = cameras.Where(cam => cam.Contains("w")).Select(cam => cam.ToCharArray()).Select(cam => cam[0] - '0').ToHashSet();

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distance = new double[nodes];
            Edge[] edgeParents = new Edge[nodes];
            int[] indexParents = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                distance[i] = double.PositiveInfinity;
                indexParents[i] = -1;
            }

            distance[source] = 0;

            OrderedBag<int> bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
            bag.Add(source);

            while (bag.Count > 0)
            {
                int minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == destination)
                {
                    break;
                }

                foreach (Edge edge in graph[minNode])
                {
                    int otherNode = minNode == edge.First ? edge.Second : edge.First;

                    if (forbidden.Contains(otherNode) || forbidden.Contains(minNode))
                    {
                        continue;
                    }

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    double currentDistance = distance[minNode] + edge.Weight;

                    if (distance[otherNode] > currentDistance)
                    {
                        indexParents[otherNode] = minNode;
                        distance[otherNode] = currentDistance;
                        edgeParents[otherNode] = edge;
                        bag = new OrderedBag<int>(bag,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                    }
                }
            }

            int energy = 0;
            Edge currentEdge = edgeParents[destination];
            int currentNode = destination;
            while (currentEdge != null)
            {
                energy += currentEdge.Weight;
                currentNode = indexParents[currentNode];
                currentEdge = edgeParents[currentNode];
            }

            Console.WriteLine(energy);
        }
    }
}