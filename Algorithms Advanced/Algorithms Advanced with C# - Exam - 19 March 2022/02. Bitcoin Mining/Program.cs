namespace _02._Bitcoin_Mining
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Transaction
    {
        public Transaction(string from, string to, string hash, int size, int fees)
        {
            From = from;
            To = to;
            Hash = hash;
            Size = size;
            Fees = fees;
        }
        public string From { get; set; }
        public string To { get; set; }
        public string Hash { get; set; }
        public int Size { get; set; }
        public int Fees { get; set; }
    }

    internal class Program
    {
        private static List<Transaction> graph;
        private static double[] distance;
        private static int[] parents;

        static void Main(string[] args)
        {
            graph = new List<Transaction>();

            int nodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodes; i++)
            {
                string[] edgeArgs = Console.ReadLine()
                    .Split();

                graph.Add(new Transaction(edgeArgs[3], edgeArgs[4], edgeArgs[0], int.Parse(edgeArgs[1]), int.Parse(edgeArgs[2])));
            }

            int maxSize = 1000000;
            int fees = 0;
            int sizeUsed = 0;
            List<string> hashes = new List<string>();
            foreach (var tr in graph.OrderByDescending(t => t.Fees))
            {
                if (tr.Size <= maxSize)
                {
                    fees += tr.Fees;
                    sizeUsed += tr.Size;
                    maxSize -= tr.Size;
                    hashes.Add(tr.Hash);
                }
            }

            Console.WriteLine($"Total Size: {sizeUsed}");
            Console.WriteLine($"Total Fees: {fees}");
            Console.WriteLine(string.Join(Environment.NewLine, hashes));
        }
    }
}