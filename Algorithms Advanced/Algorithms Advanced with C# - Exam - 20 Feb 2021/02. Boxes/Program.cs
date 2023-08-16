using System;

namespace _02._Boxes
{
    using System.Collections.Generic;
    using System.Linq;

    class Box
    {
        public Box(int width, int depth, int height)
        {
            Width = width;
            Depth = depth;
            Height = height;
        }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int boxesCount = int.Parse(Console.ReadLine());

            List<Box> boxes = new List<Box>();

            for (int i = 0; i < boxesCount; i++)
            {
                int[] boxArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int width = boxArgs[0];
                int depth = boxArgs[1];
                int height = boxArgs[2];

                boxes.Add(new Box(width, depth, height));
            }

            int[] length = new int[boxesCount];
            int[] prev = new int[boxesCount];
            Array.Fill(prev, -1);

            int maxLength = 0;
            int lastIdx = -1;
            for (int current = 0; current < boxes.Count; current++)
            {
                Box currentBox = boxes[current];

                int bestLength = 1;
                int prevIdx = -1;
                for (int previous = current - 1; previous >= 0; previous--)
                {
                    Box previousBox = boxes[previous];

                    if (currentBox.Height > previousBox.Height &&
                        currentBox.Depth > previousBox.Depth &&
                        currentBox.Width > previousBox.Width &&
                        bestLength <= length[previous] + 1)
                    {
                        bestLength = length[previous] + 1;
                        prevIdx = previous;
                    }
                }

                length[current] = bestLength;
                prev[current] = prevIdx;

                if (maxLength < bestLength)
                {
                    maxLength = bestLength;
                    lastIdx = current;
                }
            }

            Console.Clear();

            Stack<string> result = new Stack<string>();
            while (lastIdx != -1)
            {
                Box box = boxes[lastIdx];
                result.Push($"{box.Width} {box.Depth} {box.Height}");
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}