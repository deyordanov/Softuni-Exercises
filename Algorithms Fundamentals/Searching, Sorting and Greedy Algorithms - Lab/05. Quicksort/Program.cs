using System;
using System.Linq;

namespace _05._Quicksort
{
    internal class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            QuickSort(0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot]
                    && numbers[right] < numbers[pivot])
                {
                    Swap(left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }
            }

            Swap(pivot, right);

            QuickSort(start, right - 1);
            QuickSort(right + 1, end);
        }

        private static void Swap(int idx1, int idx2)
        {
            int element = numbers[idx1];
            numbers[idx1] = numbers[idx2];
            numbers[idx2] = element;
        }
    }
}
