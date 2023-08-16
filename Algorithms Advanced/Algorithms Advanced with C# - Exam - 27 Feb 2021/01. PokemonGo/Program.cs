 using System;

namespace _01._PokemonGo
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        class Street
        {
            public Street(string name, int pokemons, int length)
            {
                Name = name;
                Pokemons = pokemons;
                Length = length;
            }
            public string Name { get; set; }
            public int Pokemons { get; set; }
            public int Length { get; set; }
        }
        static void Main(string[] args)
        {
            int fuel = int.Parse(Console.ReadLine());
            List<Street> streets = new List<Street>();

            string end;
            while ((end = Console.ReadLine()) != "End")
            {
                string[] streetArgs = end.Split(", ");

                streets.Add(new Street(streetArgs[0], int.Parse(streetArgs[1]), int.Parse(streetArgs[2])));
            }

            int[,] table = new int[streets.Count + 1, fuel + 1];

            for (int streetIdx = 1; streetIdx < table.GetLength(0); streetIdx++)
            {
                Street street = streets[streetIdx - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < street.Length)
                    {
                        table[streetIdx, capacity] = table[streetIdx - 1, capacity];
                    }
                    else
                    {
                        table[streetIdx, capacity] = Math.Max(
                            table[streetIdx - 1, capacity - street.Length] + street.Pokemons,
                            table[streetIdx - 1, capacity]);
                    }
                }
            }

            int row = table.GetLength(0) - 1;
            int col = table.GetLength(1) - 1;

            int fuelUsed = 0;
            int pokemonsCaught = 0;
            Stack<string> names = new Stack<string>();
            while (row != 0 && col != 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    Street street = streets[row - 1];

                    fuelUsed += street.Length;
                    pokemonsCaught += street.Pokemons;
                    names.Push(street.Name);

                    col -= street.Length;
                }

                row--;
            }

            if (names.Any())
            {
                Console.WriteLine(string.Join(" -> ", names.OrderBy(name => name)));
            }
            Console.WriteLine($"Total Pokemon caught -> {pokemonsCaught}");
            Console.WriteLine($"Fuel Left -> {fuel - fuelUsed}");
        }
    }
}
