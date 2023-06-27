using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _03._Shortest_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes + 1];
            bool[] visited = new bool[graph.Count()];
            int[] parent = new int[graph.Count()];
            Array.Fill(parent, -1);

            for (int i = 1; i <= nodes; i++)
            {
                graph[i] = new List<int>();
            }

            int edges = int.Parse(Console.ReadLine());
            for (int i = 0; i < edges; i++)
            {
                int[] pair = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                graph[pair[0]].Add(pair[1]);
            }

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            BFS(start);

            void BFS(int startNode)
            {
                Queue<int> queue = new Queue<int>();

                queue.Enqueue(startNode);
                visited[startNode] = true;

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    if (node == end)
                    {
                        Stack<int> path = GetPath(end);
                        Console.WriteLine($"Shortest path length is: {path.Count() - 1}");
                        Console.WriteLine(string.Join(" ", path));
                        break;
                    }

                    foreach (int child in graph[node])
                    {
                        if (!visited[child])
                        {
                            parent[child] = node;
                            visited[child] = true;
                            queue.Enqueue(child);
                        }
                    }
                }
            }

            Stack<int> GetPath(int end)
            {
                Stack<int> path = new Stack<int>();

                int index = end;
                while (index != -1)
                {
                    path.Push(index);
                    index = parent[index];
                }

                return path;
            }
        }
    }
}
