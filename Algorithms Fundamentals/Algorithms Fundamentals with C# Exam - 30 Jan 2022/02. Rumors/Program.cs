using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Rumors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }
            int e = int.Parse(Console.ReadLine());
            for (int i = 0; i < e; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                graph[numbers[0]].Add(numbers[1]);
                graph[numbers[1]].Add(numbers[0]);
            }

            bool[] visited = new bool[n + 1];
            visited[0] = true;
            Dictionary<int, int> rumor = new Dictionary<int, int>();
            int start = int.Parse(Console.ReadLine());
            int depth = 0;

            BFS(start);

            Console.WriteLine(string.Join(Environment.NewLine, rumor.OrderBy(x => x.Key)
                .Select(x => $"{start} -> {x.Key} ({x.Value})")));

            void BFS(int startNode)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(startNode);

                while (queue.Count > 0)
                {
                    int size = queue.Count();

                    while (size != 0)
                    {
                        int node = queue.Dequeue();
                        size--;

                        visited[node] = true;
                        if (!rumor.ContainsKey(node) && node != start)
                        {
                            rumor.Add(node, depth);
                        }

                        foreach (int child in graph[node])
                        {
                            if (!visited[child])
                            {
                                visited[child] = true;
                                queue.Enqueue(child);
                            }
                        }
                    }

                    depth++;
                }
            }
        }
    }
}
