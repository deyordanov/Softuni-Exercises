using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());
            Dictionary<int ,long> memoization = new Dictionary<int ,long>();

            Console.WriteLine(CalculateFibonacci(fib));

            long CalculateFibonacci(int fib)
            {
                if (memoization.ContainsKey(fib))
                {
                    return memoization[fib];
                }

                if (fib < 2)
                {
                    return fib;
                }

                long result = CalculateFibonacci(fib - 1) + CalculateFibonacci(fib - 2);

                memoization.Add(fib, result);

                return result;
            }
        }
    }
}
