using System;

namespace _01._Reverse_Array
{
    internal class Program
    {
        static string[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Reverse(0);
            Console.WriteLine(string.Join(" ", numbers));
        }

        static private void Reverse(int index)
        {
            if(index == numbers.Length / 2)
            {
                return;
            }

            string number = numbers[index];
            numbers[index] = numbers[numbers.Length - 1 - index];
            numbers[numbers.Length - 1 - index] = number;
            Reverse(index + 1);
        }
    }
}
