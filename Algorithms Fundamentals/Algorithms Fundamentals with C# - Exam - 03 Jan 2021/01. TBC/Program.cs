using System;

namespace _01._TBC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size1 = int.Parse(Console.ReadLine());
            int size2 = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size1, size2];
            bool[,] visited = new bool[size1, size2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int tunnels = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visited[row, col] && matrix[row, col] != 'd')
                    {
                        FindTunnels(row, col);
                        tunnels++;
                    }
                }
            }

            Console.WriteLine(tunnels);

            void FindTunnels(int row, int col)
            {
                if (row < 0 || row >= matrix.GetLength(0)
                            || col < 0 || col >= matrix.GetLength(1)
                            || matrix[row, col] == 'd'
                            || visited[row, col])
                {
                    return;
                }

                visited[row, col] = true;

                FindTunnels(row - 1, col); //up
                FindTunnels(row, col + 1); //right
                FindTunnels(row, col - 1); //left
                FindTunnels(row + 1, col); //down
                FindTunnels(row - 1, col - 1); //left diagonal up
                FindTunnels(row - 1, col + 1); //right diagonal up
                FindTunnels(row + 1, col - 1); //left diagonal down
                FindTunnels(row + 1, col + 1); //right diagonal down
            }
        }
    }
}
