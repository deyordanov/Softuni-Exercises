using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            InsertionSort();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort()
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i;
                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(j - 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int idx1, int idx2)
        {
            int element = numbers[idx1];
            numbers[idx1] = numbers[idx2];
            numbers[idx2] = element;
        }
    }
}
