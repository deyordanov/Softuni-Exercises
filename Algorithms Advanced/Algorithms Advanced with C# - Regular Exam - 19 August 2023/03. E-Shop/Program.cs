namespace _03._E_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        private static List<Item> items;
        private static Dictionary<string, List<string>> itemBonds;

        static void Main(string[] args)
        {
            items = new List<Item>();
            itemBonds = new Dictionary<string, List<string>>();

            int itemsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsCount; i++)
            {
                string[] itemArgs = Console.ReadLine().Split();

                items.Add(new Item(itemArgs[0], int.Parse(itemArgs[1]), int.Parse(itemArgs[2])));
            }

            int bondsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < bondsCount; i++)
            {
                string[] bondArgs = Console.ReadLine().Split();

                string firstItem = bondArgs[0];
                string secondItem = bondArgs[1];

                if (!itemBonds.ContainsKey(firstItem))
                {
                    itemBonds.Add(firstItem, new List<string>());
                }

                if (!itemBonds.ContainsKey(secondItem))
                {
                    itemBonds.Add(secondItem, new List<string>());
                }

                itemBonds[firstItem].Add(secondItem);
                itemBonds[secondItem].Add(firstItem);
            }

            int maxCapacity = int.Parse(Console.ReadLine());

            List<List<Item>> redistributedItems = new List<List<Item>>();
            HashSet<string> visited = new HashSet<string>();

            foreach (Item item in items)
            {
                if (visited.Contains(item.Name))
                {
                    continue;
                }

                List<Item> redistributed = new List<Item>(); 
                DFS(item.Name, redistributed, visited);

                if (redistributed.Count > 0)
                {
                    redistributedItems.Add(redistributed);
                }
            }

            List<Item> newItems = new List<Item>();
            foreach (Item item in items)
            {
                if (!visited.Contains(item.Name))
                {
                    newItems.Add(item);
                }
            }

            foreach (List<Item> collection in redistributedItems)
            {
                int weight = collection.Sum(i => i.Weight);
                int value = collection.Sum(i => i.Value);
                string name = string.Join(" ", collection.Select(i => i.Name));

                newItems.Add(new Item(name, weight, value));
            }

            int[,] table = new int[newItems.Count + 1, maxCapacity + 1];

            for (int itemIdx = 1; itemIdx < table.GetLength(0); itemIdx++)
            {
                Item item = newItems[itemIdx - 1];
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

            Stack<string> result = new Stack<string>();
            while (row != 0 && col != 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    Item item = newItems[row - 1];

                    foreach (string itemName in item.Name.Split(" "))
                    {
                        result.Push(itemName);
                    }

                    col -= item.Weight;
                }

                row--;
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));

            void DFS(string name, List<Item> redistributed, HashSet<string> visited)
            {
                if (itemBonds.ContainsKey(name) && !visited.Contains(name))
                {
                    visited.Add(name);
                    redistributed.Add(items.FirstOrDefault(i => i.Name == name));
                    foreach (string itemBond in itemBonds[name])
                    {
                        DFS(itemBond, redistributed, visited);
                    }
                }
            }
        }
    }
}