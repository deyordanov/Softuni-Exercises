using System;

namespace _02._Recursive_Drawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Figure(n);
        }

        static void Figure(int n)
        {
            if(n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            Figure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
