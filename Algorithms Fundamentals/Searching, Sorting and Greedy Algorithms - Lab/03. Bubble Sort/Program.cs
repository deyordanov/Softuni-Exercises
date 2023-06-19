using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            BubbleSort();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort()
        {
            bool sorted = false;
            int swapped = 0;

            while (!sorted)
            {
                sorted = true;

                for (int i = 1; i < numbers.Length - swapped; i++)
                {
                    int j = i - 1;
                    if (numbers[j] > numbers[i])
                    {
                        Swap(j, i);
                        sorted = false;
                    }
                }

                swapped++;
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
