using System;
using System.Linq;

namespace _06._Merge_Sort
{
    internal class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", MergeSort(numbers)));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int[] left = numbers.Take(numbers.Length / 2).ToArray();
            int[] right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];

            int leftIndex = 0;
            int rightIndex = 0;
            int mergeIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    merged[mergeIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergeIndex++] = right[rightIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergeIndex++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                merged[mergeIndex++] = right[i];
            }

            return merged;
        }
    }
}
