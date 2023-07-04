using System;
using System.Collections.Generic;

namespace _03._Strings_Mashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] str = Console.ReadLine().ToCharArray();

            Permute(0);

            void Permute(int index)
            {
                if (index >= str.Length)
                {
                    Console.WriteLine(str);
                    return;
                }

                Permute(index + 1);

                if (char.IsLetter(str[index]))
                {
                    str[index] = char.IsLower(str[index]) ? char.ToUpper(str[index]) : char.ToLower(str[index]);
                    Permute(index + 1);
                }
            }
        }
    }
}
