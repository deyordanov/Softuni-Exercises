using System;
using System.Collections.Generic;

namespace _04._Salaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[n];
            Dictionary<int, int> visited = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            int salaries = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                salaries += DFS(i);
            }

            Console.WriteLine(salaries);

            int DFS(int node)
            {
                if (visited.ContainsKey(node))
                {
                    return visited[node];
                }

                int salary = 0;

                if (graph[node].Count == 0)
                {
                    salary = 1;
                }
                else
                {
                    foreach (int child in graph[node])
                    {
                        salary += DFS(child);
                    }
                }

                visited[node] = salary; 
                return salary;
            }
        }
    }
}
