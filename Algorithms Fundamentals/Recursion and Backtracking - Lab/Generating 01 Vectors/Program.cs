using System;

namespace _3._Generating_01_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if(index >= vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for(int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVector(vector, index + 1);
            }
        }
    }
}
