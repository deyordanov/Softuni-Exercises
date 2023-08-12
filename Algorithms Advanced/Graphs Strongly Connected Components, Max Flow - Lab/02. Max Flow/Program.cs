using System;

namespace _02._Max_Flow
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            int[,] graph = new int[nodes, nodes];
            int[] prev = new int[nodes];
            Array.Fill(prev, -1);

            for (int row = 0; row < nodes; row++)
            {
                int[] nums = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < nodes; col++)
                {
                    graph[row, col] = nums[col];
                }
            }

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            int maxFlow = 0;
            while (BFS())
            {
                int minFlow = int.MaxValue;

                int to = destination;
                int from = prev[to];

                while (to != -1 && from != -1)
                {
                    minFlow = Math.Min(minFlow, graph[from, to]);

                    to = prev[to];
                    from = prev[to];
                }

                to = destination;
                from = prev[to];

                while (to != -1 && from != -1)
                {
                    graph[from, to] -= minFlow;

                    to = prev[to];
                    from = prev[to];
                }

                maxFlow += minFlow;
            }

            Console.WriteLine($"Max flow = {maxFlow}");

            bool BFS()
            {
                bool[] visited = new bool[nodes];
                Queue<int> queue = new Queue<int>();

                visited[source] = true;
                queue.Enqueue(source);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    for (int child = 0; child < graph.GetLength(1); child++)
                    {
                        if (!visited[child] && graph[node, child] > 0)
                        {
                            queue.Enqueue(child);
                            visited[child] = true;
                            prev[child] = node;
                        }
                    }
                }

                return visited[destination];
            }
        }
    }
}