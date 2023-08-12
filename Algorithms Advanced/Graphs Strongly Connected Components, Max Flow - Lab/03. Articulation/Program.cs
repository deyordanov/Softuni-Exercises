using System;

namespace _03._Articulation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depths;
        private static int[] lowPoints;
        private static int[] prev;
        private static List<int> articulationPoints;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            visited = new bool[nodes];
            depths = new int[nodes];
            lowPoints = new int[nodes];
            prev = new int[nodes];
            articulationPoints = new List<int>();

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                prev[i] = -1;
            }

            for (int i = 0; i < lines; i++)
            {
                int[] nodeArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                graph[nodeArgs[0]].AddRange(nodeArgs.Skip(1));
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                DFS(node, 1);
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");

            void DFS(int node, int currentDepth)
            {
                visited[node] = true;
                depths[node] = currentDepth;
                lowPoints[node] = currentDepth;

                int childCount = 0;
                bool isArticulationPoint = false;

                foreach (int child in graph[node])
                {
                    if (!visited[child])
                    {
                        prev[child] = node;
                        DFS(child, currentDepth + 1);

                        childCount += 1;

                        if (lowPoints[child] >= depths[node])
                        {
                            isArticulationPoint = true;
                        }

                        lowPoints[node] = Math.Min(lowPoints[node], lowPoints[child]); 
                    }
                    else if (prev[node] != child)
                    {
                        lowPoints[node] = Math.Min(lowPoints[node], depths[child]);
                    }
                }

                
                //if the current node is the root and it has more than one child OR if the current node is not the root, but it is an articulation point
                if (prev[node] == -1 && childCount > 1 ||
                    prev[node] != -1 && isArticulationPoint)
                {
                    articulationPoints.Add(node);
                }
            }
        }
    }
}
