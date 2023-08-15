using System;

namespace _02._Battle_Points
{
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] energy = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] points = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int energyPoints = int.Parse(Console.ReadLine());

            int[,] table = new int[energy.Length + 1, energyPoints + 1];

            for (int enemyIdx = 1; enemyIdx < table.GetLength(0); enemyIdx++)
            {
                int enemyEnergy = energy[enemyIdx - 1];
                int battlePoints = points[enemyIdx - 1];

                for (int energyCapacity = 1; energyCapacity < table.GetLength(1); energyCapacity++)
                {
                    if (energyCapacity < enemyEnergy)
                    {
                        table[enemyIdx, energyCapacity] = table[enemyIdx - 1, energyCapacity];
                    }
                    else
                    {
                        table[enemyIdx, energyCapacity] = Math.Max(table[enemyIdx - 1, energyCapacity],
                            table[enemyIdx - 1, energyCapacity - enemyEnergy] + battlePoints);
                    }
                }
            }

            Console.WriteLine(table[table.GetLength(0) - 1, table.GetLength(1) - 1]);
        }
    }
}