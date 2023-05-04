using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Paths_in_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] numbers = Console.ReadLine().ToCharArray();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            List<string> directions = new List<string>();
            FindPath(0, 0, string.Empty, matrix, directions);
        }

        static void FindPath(int row, int col, string direction, char [,] maze, List<string> directions)
        {
            if (row < 0 || row >= maze.GetLength(0)
                || col < 0 || col >= maze.GetLength(1))
            {
                return;
            }

            if (maze[row, col] == '*' || maze[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (maze[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            maze[row, col] = 'v';

            FindPath(row - 1, col, "U", maze, directions);
            FindPath(row + 1, col, "D", maze, directions);
            FindPath(row, col - 1, "L", maze, directions);
            FindPath(row, col + 1, "R", maze, directions);

            maze[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
