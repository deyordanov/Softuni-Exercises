using System;

namespace _03._Find_Bi_Connected_Components
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            int[] depth = new int[nodes];
            int[] lowpoint = new int[nodes];
            bool[] visited = new bool[nodes];
            int[] prev = new int[nodes];

            Stack<int> result = new Stack<int>();

            int componentsCount = 0;

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                prev[i] = -1;
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                DFS(node, 1);
            }

            Console.WriteLine($"Number of bi-connected components: {componentsCount + 1}");

            void DFS(int node, int currentDepth)
            {
                visited[node] = true;
                depth[node] = currentDepth;
                lowpoint[node] = currentDepth;

                int childCount = 0;
                bool isArticulationPoint = false;

                foreach (int child in graph[node])
                {
                    if (!visited[child])
                    {
                        result.Push(node);
                        result.Push(child);

                        prev[child] = node;
                        DFS(child, currentDepth + 1);

                        childCount += 1;

                        if (prev[node] == -1 && childCount > 1 ||
                            prev[node] != -1 && lowpoint[child] >= depth[node])
                        {
                            HashSet<int> component = new HashSet<int>();

                            while (true)
                            {
                                int stackChild = result.Pop();
                                int stackNode = result.Pop();

                                component.Add(stackNode);
                                component.Add(stackChild);

                                if (stackNode == node &&
                                    stackChild == child)
                                {
                                    break;
                                }
                            }

                            componentsCount++;
                        }

                        lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                    }
                    else if (prev[node] != child && depth[child] < lowpoint[node])
                    {
                        lowpoint[node] = depth[child];
                        result.Push(node);
                        result.Push(child);
                    }
                }
            }
        }
    }
}
