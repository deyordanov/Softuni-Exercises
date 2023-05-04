using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(Sum(numbers, 0));
        }

        static int Sum(int[] numbers, int index)
        {
            if(index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, index + 1);    
        }
    }
}
