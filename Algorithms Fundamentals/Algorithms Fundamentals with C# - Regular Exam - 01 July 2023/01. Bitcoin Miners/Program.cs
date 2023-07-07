using System;
using System.Collections.Generic;

namespace _01._Bitcoin_Miners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Dictionary<string, long> memo = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));

            long GetBinom(int row, int col)
            {
                if (col == row || col == 0)
                {
                    return 1;
                }

                string key = $"{row}{col}";

                if (memo.ContainsKey(key))
                {
                    return memo[key];
                }

                long result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);

                memo.Add(key, result);

                return result;
            }
        }
    }
}
