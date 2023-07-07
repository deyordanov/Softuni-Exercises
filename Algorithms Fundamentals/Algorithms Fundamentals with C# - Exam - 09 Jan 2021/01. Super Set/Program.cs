using System;
using System.Linq;

namespace _01._Super_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine();
            for (int i = 1; i <= numbers.Length; i++)
            {
                Combinations(new int[i], 0, 0);
            }

            void Combinations(int[] combination, int index, int start)
            {
                if (index >= combination.Length)
                {
                    Console.WriteLine(string.Join(" ", combination));
                    return;
                }

                for (int i = start; i < numbers.Length; i++)
                {
                    combination[index] = numbers[i];
                    Combinations(combination, index + 1,i + 1);
                }
            }
        }
    }
}
