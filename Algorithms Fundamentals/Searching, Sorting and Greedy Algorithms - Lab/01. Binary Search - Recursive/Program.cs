using System;
using System.Linq;

namespace _01._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, number, 0, numbers.Length - 1));
        }

        public static int BinarySearch(int[] array, int number, int left, int right)
        {
            while (left <= right)
            {
                int middle = (right + left) / 2;

                if (array[middle] == number)
                {
                    return middle;
                }

                if (array[middle] < number)
                {
                    BinarySearch(array, number, middle + 1, right);
                }
                else
                {
                    BinarySearch(array, number, left, middle - 1);
                }
            }
            return -1;
        }
    }
}