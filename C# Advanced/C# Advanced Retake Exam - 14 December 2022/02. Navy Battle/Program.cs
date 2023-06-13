using System;

namespace NavyBattle2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            int battlefieldSize = int.Parse(Console.ReadLine());

            string[,] battleField = new string[battlefieldSize, battlefieldSize];

            int submRow = -1;
            int submCol = -1;

            int cruisersHit = 0;
            int minesHit = 0;

            for (int i = 0; i < battlefieldSize; i++)
            {
                string rowInput = Console.ReadLine();
                for (int j = 0; j < battlefieldSize; j++)
                {
                    battleField[i, j] = rowInput[j].ToString();
                    if (rowInput[j] == 'S')
                    {
                        battleField[i, j] = "-";
                        submRow = i;
                        submCol = j;
                    }
                }
            }

            while (true)
            {
                if (minesHit == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submRow}, {submCol}]!");
                    break;
                }
                if (cruisersHit == 3)
                {
                    Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    break;
                }
                string command = Console.ReadLine().ToLower();

                if (command == "left")
                {
                    submCol--;
                }
                if (command == "right")
                {
                    submCol++;
                }
                if (command == "up")
                {
                    submRow--;
                }
                if (command == "down")
                {
                    submRow++;
                }

                if (battleField[submRow, submCol] == "C")
                {
                    battleField[submRow, submCol] = "-";
                    cruisersHit++;
                }
                if (battleField[submRow, submCol] == "*")
                {
                    battleField[submRow, submCol] = "-";
                    minesHit++;
                }
            }

            battleField[submRow, submCol] = "S";

            for (int i = 0; i < battlefieldSize; i++)
            {
                for (int j = 0; j < battlefieldSize; j++)
                {
                    Console.Write(battleField[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
