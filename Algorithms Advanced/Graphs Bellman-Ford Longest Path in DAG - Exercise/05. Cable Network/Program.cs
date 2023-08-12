using System;

namespace _05._Cable_Network
{
    using System.Collections.Generic;
    using System.Linq;

    class CustomPriorityQueue
    {
        private List<Edge> edges;
        public CustomPriorityQueue()
        {
            edges = new List<Edge>();
        }

        public CustomPriorityQueue(ICollection<Edge> edges)
        {
            this.edges = this.edges;
        }

        public void Add(Edge edge)
        {
            this.edges.Add(edge);
            this.edges = OrderEdges;
        }

        public void AddMany(ICollection<Edge> edges)
        {
            this.edges.AddRange(edges);
            this.edges = OrderEdges;
        }
        public int Count => this.edges.Count;

        public Edge RemoveFirst()
        {
            Edge edgeToRemove = this.edges.FirstOrDefault();
            this.edges.Remove(edgeToRemove);

            return edgeToRemove;
        }

        private List<Edge> OrderEdges => this.edges.OrderBy(edge => edge.Weight).ToList();
    }

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
        private static HashSet<int> spanningForest;

        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            spanningForest = new HashSet<int>();

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                string[] edgeArgs = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int first = int.Parse(edgeArgs[0]);
                int second = int.Parse(edgeArgs[1]);
                int weight = int.Parse(edgeArgs[2]);

                Edge edge = new Edge(first, second, weight);

                graph[first].Add(edge);
                graph[second].Add(edge);

                if (edgeArgs.Length == 4)
                {
                    spanningForest.Add(first);
                    spanningForest.Add(second);
                }
            }

            Console.WriteLine($"Budget used: {Prim()}");

            int Prim()
            {
                CustomPriorityQueue bag = new CustomPriorityQueue();

                foreach (int node in spanningForest)
                {
                    bag.AddMany(graph[node]);
                }

                int budgetUsed = 0;
                while (bag.Count > 0)
                {
                    Edge minEdge = bag.RemoveFirst();

                    int notPresentNode = -1;

                    if (spanningForest.Contains(minEdge.First) &&
                        !spanningForest.Contains(minEdge.Second))
                    {
                        notPresentNode = minEdge.Second;
                    }

                    if (spanningForest.Contains(minEdge.Second) &&
                        !spanningForest.Contains(minEdge.First))
                    {
                        notPresentNode = minEdge.First;
                    }

                    if (notPresentNode == -1)
                    {
                        continue;
                    }

                    if (budgetUsed + minEdge.Weight > budget)
                    {
                        break;
                    }

                    budgetUsed += minEdge.Weight;
                    spanningForest.Add(notPresentNode);
                    bag.AddMany(graph[notPresentNode]);
                }

                return budgetUsed;
            }
        }
    }
}