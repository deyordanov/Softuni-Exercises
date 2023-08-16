using System;

namespace _03._Emergency_Plan
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    using static System.Net.Mime.MediaTypeNames;

    internal class Program
    {
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

        static void Main(string[] args)
        {
            //A bad and unoptimized solution!!!!!!!!!!

            int nodes = int.Parse(Console.ReadLine());
            List<int> exits = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Dictionary<int, string> exitTime = new Dictionary<int, string>();

            List<Edge>[] graph = new List<Edge>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            int edges = int.Parse(Console.ReadLine());
            for (int i = 0; i < edges; i++)
            {
                string[] edgeArgs = Console.ReadLine().Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);

                int first = int.Parse(edgeArgs[0]);
                int second = int.Parse(edgeArgs[1]);

                int weight = ConvertToSeconds(edgeArgs[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries));

                graph[first].Add(new Edge(first, second, weight));
                graph[second].Add(new Edge(first, second, weight));
            }

            int time = ConvertToSeconds(Console.ReadLine().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries));

            double[] distance = new double[nodes];
            int[] prev = new int[nodes];

            for (int node = 0; node < nodes; node++)
            {
                if (exits.Contains(node))
                {
                    continue;
                }

                for (int i = 0; i < nodes; i++)
                {
                    prev[i] = -1;
                    distance[i] = double.PositiveInfinity;
                }

                OrderedBag<int> bag =
                    new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                bag.Add(node);
                distance[node] = 0;

                while (bag.Count > 0)
                {
                    int minNode = bag.RemoveFirst();

                    foreach (Edge edge in graph[minNode])
                    {
                        int otherNode = minNode == edge.First ? edge.Second : edge.First;

                        if (double.IsPositiveInfinity(distance[otherNode]))
                        {
                            bag.Add(otherNode);
                        }

                        double currentDistance = distance[minNode] + edge.Weight;

                        if (currentDistance < distance[otherNode])
                        {
                            distance[otherNode] = currentDistance;
                            prev[otherNode] = minNode;
                            bag = new OrderedBag<int>(bag,
                                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                        }
                    }
                }

                int exit = (int)(exits.Select(ex => distance[ex]).Min());
                int minutes = (int)(exit / 60);
                var minStr = exit / 60 >= 10 ? $"{minutes}" : $"0{minutes}";
                int seconds = (int)(exit % 60);
                var secStr = exit % 60 >= 10 ? $"{seconds}" : $"0{seconds}";

                if (!exitTime.ContainsKey(node))
                {
                    exitTime[node] = $"{minStr}:{secStr}";
                }
            }

            foreach (var key in exitTime.Keys)
            {
                if (exitTime[key].Length > 5)
                {
                    Console.WriteLine($"Unreachable {key} (N/A)");
                    continue;
                }

                int hours = (int)((ConvertToSeconds(exitTime[key].Split(new [] { ":" }, StringSplitOptions.RemoveEmptyEntries)) / 60) / 60);
                string hrsStr = hours >= 10 ? $"{hours}" : $"0{hours}";
                if (ConvertToSeconds(exitTime[key].Split(new [] { ":"}, StringSplitOptions.RemoveEmptyEntries)) > time)
                {
                    Console.WriteLine($"Unsafe {key} ({hrsStr}:{exitTime[key]})");
                }
                else
                {
                    Console.WriteLine($"Safe {key} ({hrsStr}:{exitTime[key]})");
                }
            }

            int ConvertToSeconds(string[] txt)
                => int.Parse(txt[0]) * 60 + int.Parse(txt[1]);
        }
    }
}