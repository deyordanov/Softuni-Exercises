using System;
using System.Globalization;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            SelectionSort();
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSort()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        Swap(j, i);
                    }
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
