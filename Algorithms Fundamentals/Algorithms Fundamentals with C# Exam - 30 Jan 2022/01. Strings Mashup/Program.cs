using System;
using System.Linq;
using System.Text;

namespace _01._Strings_Mashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] str = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            int size = int.Parse(Console.ReadLine());
            char[] combination = new char[size];

            Combinations(0, 0);

            void Combinations(int index, int start)
            {
                if (index == combination.Length)
                {
                    Console.WriteLine(string.Join("", combination));
                    return;
                }

                for (int i = start; i < str.Length; i++)
                {
                    combination[index] = str[i];
                    Combinations(index + 1, i);
                }
            }
        }
    }
}
