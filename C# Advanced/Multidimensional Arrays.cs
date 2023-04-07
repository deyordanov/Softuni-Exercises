using System;
using System.Linq;

namespace Target_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shot = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int shotRow = shot[0];
            int shotCol = shot[1];
            int radius = shot[2];
            char[,] matrix = new char[input[0], input[1]];
            int indexOfSnake = 0;
            int counter = matrix.GetLength(0) - 1;
            for(int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if(row == counter)
                {
                    for(int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }
                        matrix[row, col] = snake[indexOfSnake++];
                    }
                    counter -= 2;
                }
                else
                {
                    for(int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }
                        matrix[row, col] = snake[indexOfSnake++];            
                    }
                }
            }

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    double distanceBetweenPoints = Math.Sqrt(Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2));
                    if(distanceBetweenPoints <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            //for(int col = 0; col < matrix.GetLength(1); col++)
            //{
            //    for(int row = 0; row < matrix.GetLength(0); row++)
            //    {
            //        if (matrix[row, col] != ' ')
            //        {
            //            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == ' ')
            //            {
            //                matrix[row + 1, col] = matrix[row, col];
            //                matrix[row, col] = ' ';
            //                if(col > 0)
            //                {
            //                    col--;
            //                }
            //                if(row > 0)
            //                {
            //                    row--;
            //                }
            //            }                       
            //        }
            //    }
            //}


            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int i = row; i > 0; i--)
                    {
                        if (matrix[i, col] == ' ' && matrix[i - 1, col]  != ' ')
                        {
                            matrix[i, col] = matrix[i - 1, col];
                            matrix[i - 1, col] = ' ';
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
