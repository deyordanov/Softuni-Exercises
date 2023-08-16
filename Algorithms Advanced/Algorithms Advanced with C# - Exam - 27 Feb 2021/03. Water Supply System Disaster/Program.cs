using System;

namespace _03._Find_Bi_Connected_Components
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine()) + 1;
            int parts = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            int[] depth = new int[nodes];
            int[] lowpoint = new int[nodes];
            bool[] visited = new bool[nodes];
            int[] prev = new int[nodes];

            Dictionary<int, int> articulationPointsPerNode = new Dictionary<int, int>();

            Stack<int> result = new Stack<int>();

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                prev[i] = -1;
            }

            for (int i = 1; i < nodes; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                graph[i].AddRange(edgeArgs);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                DFS(node, 1);
            }

            foreach (int node in articulationPointsPerNode.Keys)
            {
                if (articulationPointsPerNode[node] + 1 == parts)
                {
                    Console.WriteLine(node);
                    return;
                }
            }

            Console.WriteLine(0);

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

                            if (!articulationPointsPerNode.ContainsKey(node))
                            {
                                articulationPointsPerNode.Add(node, 0);
                            }

                            articulationPointsPerNode[node]++;
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