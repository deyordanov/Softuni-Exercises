using System;

namespace _02._Maximum_Tasks_Assignment
{
    using System.Collections;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());

            int nodes = people + tasks + 2;

            bool[,] graph = new bool[nodes, nodes];
            int[] prev = new int[nodes];
            Array.Fill(prev, -1);

            for (int person = 1; person <= people; person++)
            {
                graph[0, person] = true;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph[task, nodes - 1] = true;
            }

            for (int person = 1; person <= people; person++)
            {
                string graphArgs = Console.ReadLine();

                for (int task = 0; task < graphArgs.Length; task++)
                {
                    if (graphArgs[task] == 'Y')
                    {
                        graph[person, people + task + 1] = true;
                    }
                }
            }

            int source = 0;
            int destination = nodes - 1;

            while (BFS())
            {
                int to = destination;
                int from = prev[to];

                while (to != -1 && from != -1)
                {
                    graph[from, to] = false;
                    graph[to, from] = true;

                    to = prev[to];
                    from = prev[to];
                }
            }

            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (graph[task, person])
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - people}");
                    }
                }
            }

            bool BFS()
            {
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[nodes];

                queue.Enqueue(source);
                visited[source] = true;

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    for (int child = 0; child < graph.GetLength(1); child++)
                    {
                        if (!visited[child] && graph[node, child])
                        {
                            prev[child] = node;
                            visited[child] = true;
                            queue.Enqueue(child);
                        }
                    }
                }

                return visited[destination];
            }
        }
    }
}
