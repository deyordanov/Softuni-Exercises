using System;

namespace _02._0_1_Knapsack
{
    using System.Collections.Generic;

    class Item
    {
        public Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            List<Item> items = new List<Item>();

            string end;
            while ((end = Console.ReadLine()) != "end")
            {
                string[] itemArgs = end.Split(" ");

                items.Add(new Item(itemArgs[0], int.Parse(itemArgs[1]), int.Parse(itemArgs[2])));
            }

            int[,] table = new int[items.Count + 1, maxCapacity + 1];

            for (int itemIdx = 1; itemIdx < table.GetLength(0); itemIdx++)
            {
                Item item = items[itemIdx - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < item.Weight)
                    {
                        table[itemIdx, capacity] = table[itemIdx - 1, capacity];
                    }
                    else
                    {
                        table[itemIdx, capacity] = Math.Max(
                            table[itemIdx - 1, capacity],
                            table[itemIdx - 1, capacity - item.Weight] + item.Value);
                    }
                }
            }

            int row = table.GetLength(0) - 1;
            int col = table.GetLength(1) - 1;

            SortedSet<string> result = new SortedSet<string>();
            int totalWeight = 0;
            int totalValue = 0;

            while (row != 0 && col != 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    Item item = items[row - 1];

                    result.Add(item.Name);
                    totalWeight += item.Weight;
                    totalValue += item.Value;

                    col -= item.Weight;
                }

                row--;
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}