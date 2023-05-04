using System;
using System.Collections.Generic;

namespace _6._Queens_Puzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        static void Main(string[] args)
        {
            const int sizeOfBoard = 8;
            char[,] board = new char[sizeOfBoard, sizeOfBoard];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '-';
                }
            }

            PlaceQueens(board, 0);
        }

        private static void PlaceQueens(char[,] board, int row)
        {
            if(row == board.GetLength(0))
            {
                PrintBoard(board);
                Console.WriteLine();
                return;
            }
            for(int col = 0; col < board.GetLength(0); col++)
            {
                if(CanPlaceQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);
                    board[row, col] = '*';

                    PlaceQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                    board[row, col] = '-';
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col) 
            => !attackedRows.Contains(row) && !attackedCols.Contains(col)
            && !attackedLeftDiagonals.Contains(row - col) && !attackedRightDiagonals.Contains(row + col);

        static void PrintBoard(char[,] board)
        {
            for(int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
