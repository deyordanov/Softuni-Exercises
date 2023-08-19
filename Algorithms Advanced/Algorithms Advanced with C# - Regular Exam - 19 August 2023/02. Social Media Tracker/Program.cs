namespace _02._Social_Media_Tracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public Edge(string from, string to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
        public string From { get; set; }
        public string To { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<string, List<Edge>> graph;
        private static List<Edge> edges;
        private static Dictionary<string, List<double>> distance;
        private static Dictionary<string, string> prev;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<Edge>>();
            edges = new List<Edge>();

            int relationShipsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < relationShipsCount; i++)
            {
                string[] relationshipArgs = Console.ReadLine().Split(" ");

                string firstPerson = relationshipArgs[0];
                string secondPerson = relationshipArgs[1];

                if (!graph.ContainsKey(firstPerson))
                {
                    graph.Add(firstPerson, new List<Edge>());
                }

                if (!graph.ContainsKey(secondPerson))
                {
                    graph.Add(secondPerson, new List<Edge>());
                }
                Edge edge = new Edge(firstPerson, secondPerson, int.Parse(relationshipArgs[2]));


                graph[firstPerson].Add(edge);
                graph[secondPerson].Add(edge);

                edges.Add(edge);
            }

            distance = new Dictionary<string, List<double>>();
            prev = new Dictionary<string, string>();

            foreach (string node in graph.Keys)
            {
                if (!distance.ContainsKey(node))
                {
                    distance.Add(node, new List<double>());
                    distance[node].Add(double.NegativeInfinity);
                    distance[node].Add(0);
                }

                if (!prev.ContainsKey(node))
                {
                    prev.Add(node, string.Empty);
                }
            }

            string source = Console.ReadLine();
            string destination = Console.ReadLine();

            distance[source][0] = 0;

            Stack<string> topologicallySorted = TopologicalSort();

            while (topologicallySorted.Count > 0)
            {
                string node = topologicallySorted.Pop();

                foreach (Edge edge in graph[node])
                {
                    double currentDistance = distance[edge.From][0] + edge.Weight;
                    double currentHops = distance[edge.From][1] + 1;

                    if (currentDistance > distance[edge.To][0] ||
                        currentDistance == distance[edge.To][0] && currentHops < distance[edge.To][1])
                    {
                        prev[edge.To] = edge.From;
                        distance[edge.To][0] = currentDistance;
                        distance[edge.To][1] = currentHops;
                    }
                }
            }

            Stack<string> path = new Stack<string>();
            string currentNode = destination;
            while (currentNode != string.Empty)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine($"({distance[destination][0]}, {path.Count - 1})");

            Stack<string> TopologicalSort()
            {
                Stack<string> result = new Stack<string>();
                HashSet<string> visited = new HashSet<string>();

                foreach (string node in graph.Keys)
                {
                    DFS(node, result, visited);
                }

                return result;
            }

            void DFS(string node, Stack<string> result, HashSet<string> visited)
            {
                if (visited.Contains(node))
                {
                    return;
                }

                visited.Add(node);

                foreach (Edge edge in graph[node])
                {
                    string child = edge.To;
                    DFS(child, result, visited);
                }

                result.Push(node);
            }
        }
    }
}