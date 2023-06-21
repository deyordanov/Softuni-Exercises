using System;

namespace _02._Nested_Loops
{
    internal class Program
    {
        static int[] permutation;
        static int n;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            permutation = new int[n];
            Permute(0);
        }

        private static void Permute(int index)
        {
            if(index == permutation.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for(int i = 1; i <= n; i++)
            {
                permutation[index] = i;
                Permute(index + 1);
            }
        }
    }
}
