using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(input[0]);
                if (input.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    graph[node] = input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }
            }

            for (int i = 0; i < p; i++)
            {
                int[] input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int start = input[0];
                int destination = input[1];

                HashSet<int> visited = new HashSet<int>();
                Dictionary<int, int> parent = new Dictionary<int, int>();
                parent[start] = -1;

                Console.WriteLine($"{{{start}, {destination}}} -> {BFS(start, visited, parent, destination)}");
            }
           

            int BFS(int startNode, HashSet<int> visited, Dictionary<int, int> parent, int destination)
            {
                Queue<int> queue = new Queue<int>();

                queue.Enqueue(startNode);
                visited.Add(startNode);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    if (node == destination)
                    {
                        int pathLength = 0;
                        int index = destination;
                        while (index != -1)
                        {
                            pathLength++;
                            index = parent[index];
                        }

                        return pathLength - 1;
                    }

                    foreach (int child in graph[node])
                    {
                        if (!visited.Contains(child))
                        {
                            parent[child] = node;
                            visited.Add(child);
                            queue.Enqueue(child);
                        }
                    }
                }

                return -1;
            }
        }
    }
}
