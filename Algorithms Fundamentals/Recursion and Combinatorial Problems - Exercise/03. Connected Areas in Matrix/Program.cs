using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Connected_Areas_in_Matrix
{
    internal class Program
    {
        static char[,] matrix;

        class Area
        {
            public Area(int row, int col)
            {
                Row = row;
                Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public int Size { get; set; }
        }
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }


            List<Area> areas =  new List<Area>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Area area = new Area(row, col);
                    Areas(row, col, area);
                    if(area.Size > 0)
                    {
                        areas.Add(area);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            int index = 1;
            Console.WriteLine(string.Join(Environment.NewLine, areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col).Select(a => $"Area #{index++} at ({a.Row}, {a.Col}), size: {a.Size}")));
        }

        private static void Areas(int row, int col, Area area)
        {
            if(row < 0 || row >= matrix.GetLength(0)
            || col < 0 || col >= matrix.GetLength(1)
            || matrix[row, col] == '*'
            || matrix[row, col] == '1')
            {
                return;
            }

            matrix[row, col] = '1';
            area.Size++;

            Areas(row - 1, col, area); //UP
            Areas(row, col + 1, area); //RIGHT
            Areas(row + 1, col, area); //DOWN
            Areas(row, col - 1, area); //LEFT
        }
    }
}
