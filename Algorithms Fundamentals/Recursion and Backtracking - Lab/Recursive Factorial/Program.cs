using System;

namespace _04._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int factorial = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(factorial));
        }

        private static int Factorial(int factorial)
        {
            if(factorial == 0)
            {
                return 1;
            }

            return factorial * Factorial(factorial - 1);
        }
    }
}
