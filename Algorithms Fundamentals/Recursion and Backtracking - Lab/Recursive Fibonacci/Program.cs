using System;

namespace _07._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(fib));
        }

        private static int Fibonacci(int fib)
        {
            if(fib == 0 || fib == 1)
            {
                return 1;
            }

            return Fibonacci(fib - 1) + Fibonacci(fib - 2);
        }
    }
}
