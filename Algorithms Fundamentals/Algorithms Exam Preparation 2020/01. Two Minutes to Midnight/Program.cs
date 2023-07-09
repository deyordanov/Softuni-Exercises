using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Two_Minutes_to_Midnight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Dictionary<string, long> data = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));

            long GetBinom(int row, int col)
            {
                if (row == col || col == 0)
                {
                    return 1;
                }

                string key = $"{row} {col}";

                if (data.ContainsKey(key))
                {
                    return data[key];
                }

                long result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
                data.Add(key, result);

                return result;
            }
        }
    }
}
