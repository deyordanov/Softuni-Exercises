using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string node = input[0];
                List<string> children = input[1].Split(" ").ToList();
                graph.Add(node, children);

                foreach (string child in children)
                {
                    edges.Add(new Edge(node, child));
                }
            }

            List<Edge> removed = new List<Edge>();
            foreach (Edge edge in edges.OrderBy(e => e.First).ThenBy(e => e.Second))
            {
                bool result = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                if (result)
                {
                    if (BFS(edge.First, edge.Second))
                    {
                        removed.Add(edge);
                    }
                    else
                    {
                        graph[edge.First].Add(edge.Second);
                        graph[edge.Second].Add(edge.First);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {removed.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, removed));

            bool BFS(string start, string destination)
            {
                Queue<string> queue = new Queue<string>();
                HashSet<string> visited = new HashSet<string>();

                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    string node = queue.Dequeue();

                    if (node == destination)
                    {
                        return true;
                    }

                    foreach (string child in graph[node])
                    {
                        if (!visited.Contains(child))
                        {
                            visited.Add(child);
                            queue.Enqueue(child);
                        }
                    }
                }

                return false;
            }
        }

        class Edge
        {
            public Edge(string first, string second)
            {
                First = first;
                Second = second;
            }
            public string First { get; set; }

            public string Second { get; set; }

            public override string ToString()
            {
                return $"{First} - {Second}";
            }
        }
    }
}
