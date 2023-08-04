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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parent;
        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            int edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
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
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            parent = new int[largestNode + 1];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            distance[startNode] = 0;

            OrderedBag<int> priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            priorityQueue.Add(startNode);

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(distance[minNode]))
                {
                    break;
                }

                if (minNode == endNode)
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

                    double currentDistance = distance[minNode] + edge.Weight;

                    if (currentDistance < distance[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = currentDistance;
                        priorityQueue = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
                    } 
                }
            }

            if (double.IsPositiveInfinity(distance[endNode]))
            {
                Console.WriteLine("There is no such path.");
                return;
            }

            Stack<int> path = new Stack<int>();
            int currentNode = endNode;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(distance[endNode]);
            Console.WriteLine(string.Join(" ", path));
        }
    }
}