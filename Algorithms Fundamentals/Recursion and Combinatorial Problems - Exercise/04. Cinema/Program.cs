using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cinema
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] seats = new string[people.Count];
            bool[] locked = new bool[people.Count];

            string end;
            while ((end = Console.ReadLine()) != "generate")
            {
                string[] input = end.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                people.Remove(input[0]);
                seats[int.Parse(input[1]) - 1] = input[0];
                locked[int.Parse(input[1]) - 1] = true;
            }

            Permute(0);

            void Permute(int index)
            {
                if (index >= people.Count())
                {
                    Print();
                    return;
                }

                Permute(index + 1);

                for (int i = index + 1; i < people.Count(); i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }

            void Print()
            {
                int idx = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (!locked[i])
                    {
                        seats[i] = people[idx++];
                    }
                }

                Console.WriteLine(string.Join(" ", seats));
            }


            void Swap(int idx1, int idx2)
            {
                string person = people[idx1];
                people[idx1] = people[idx2];
                people[idx2] = person;
            }
        }

    }
}
