using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _06._Road_Reconstruction
{
    internal class Program
    {
        public static bool[] visited;
        static void Main(string[] args)
        {
            int buildings = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[buildings];
            for (int i = 0; i < buildings; i++)
            {
                graph[i] = new List<int>();
            }

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < streets; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);

                edges.Add(new Edge(input[0], input[1]));
            }

            Console.WriteLine("Important streets:");
            foreach (Edge edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];
                DFS(0);

                if (visited.Contains(false))
                {
                    Console.WriteLine(new Edge(edge.First, edge.Second));
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }

            void DFS(int node)
            {
                if (visited[node])
                {
                    return;
                }

                visited[node] = true;   

                foreach (int child in graph[node])
                {
                    DFS(child);
                }
            }
        }

        class Edge
        {
            public Edge(int first, int second)
            {
                First = Math.Min(first, second);
                Second = Math.Max(first, second);
            }
            public int First { get; set; }
            public int Second { get; set; }

            public override string ToString()
            {
                return $"{First} {Second}";
            }
        }
    }
}
