namespace _01._Dora_the_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parent;
        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                List<int> edgeArgs = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];
                int weight = edgeArgs[2];

                Edge edge = new Edge(firstNode, secondNode, weight);

                if (!edgesByNode.ContainsKey(firstNode))
                {
                    edgesByNode.Add(firstNode, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(secondNode))
                {
                    edgesByNode.Add(secondNode, new List<Edge>());
                }

                edgesByNode[firstNode].Add(edge);
                edgesByNode[secondNode].Add(edge);
            }

            int largestNode = edgesByNode.Keys.Max();

            distance = new double[largestNode + 1];
            parent = new int[largestNode + 1];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }

            int time = int.Parse(Console.ReadLine());

            int startCity = int.Parse(Console.ReadLine());
            int endCity = int.Parse(Console.ReadLine());

            distance[startCity] = 0;

            OrderedBag<int> priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            priorityQueue.Add(startCity);

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(distance[minNode]))
                {
                    break;
                }

                if (minNode == endCity)
                {
                    break;
                }

                foreach (Edge edge in edgesByNode[minNode])
                {
                    int otherNode = edge.First == minNode ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double currentDistance = minNode == startCity ? distance[minNode] + edge.Weight : distance[minNode] + edge.Weight + time;

                    if (currentDistance < distance[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = currentDistance;
                        priorityQueue = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int currentNode = endCity;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine($"Total time: {distance[endCity]}");
            Console.WriteLine(string.Join(Environment.NewLine, path));
        }
    }
}