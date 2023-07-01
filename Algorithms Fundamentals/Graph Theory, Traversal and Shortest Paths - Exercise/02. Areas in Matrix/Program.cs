using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Areas_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            char[,] matrix = new char[r, c];
            bool[,] visited = new bool[r, c];
            Dictionary<char, int> areas = new Dictionary<char, int>();

            int areasVisited = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                    visited[row, col] = false;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char symbol = matrix[row, col];
                    if (!visited[row, col])
                    {
                        DFS(row, col, symbol);
                        if (!areas.ContainsKey(symbol))
                        {
                            areas.Add(symbol, 0);
                        }
                        areas[symbol]++;
                        areasVisited++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areasVisited}");
            foreach (var area in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }

            void DFS(int row, int col, char symbol)
            {
                if (row < 0
                    || row >= matrix.GetLength(0) 
                    || col < 0 
                    || col >= matrix.GetLength(1)
                    || matrix[row, col] != symbol
                    || visited[row, col])
                {
                    return;
                }

                visited[row, col] = true;

                DFS(row - 1, col, symbol); //up
                DFS(row, col + 1, symbol); //right
                DFS(row, col - 1, symbol); //left
                DFS(row + 1, col, symbol); //down
            }
        }
    }
}
