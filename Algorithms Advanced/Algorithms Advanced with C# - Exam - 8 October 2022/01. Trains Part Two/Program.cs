using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01._Dijkstra_s_Algorithm
{
    class Edge
    {
        public Edge(int first, int second, int weight)
        {
            this.First = first;
            this.Second = second;
            this.Weight = weight;
        }

        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;
        private static double[] distance;
        private static int[] parent;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            parent = new int[nodes];
            distance = new double[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
                parent[i] = -1;
                distance[i] = double.PositiveInfinity;
            }

            int[] dest = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int source = dest[0];
            int destination = dest[1];

            for (int i = 0; i < edges; i++)
            {
                List<int> edgeArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(firstNode, secondNode, weight);

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            distance[source] = 0;

            OrderedBag<int> priorityQueue =
                new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            priorityQueue.Add(source);

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(distance[minNode]))
                {
                    break;
                }

                if (minNode == destination)
                {
                    break;
                }

                foreach (Edge edge in graph[minNode])
                {
                    int otherNode = edge.First == minNode ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double currentDistance = distance[minNode] + edge.Weight;

                    if (currentDistance < distance[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = currentDistance;
                        priorityQueue = new OrderedBag<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}