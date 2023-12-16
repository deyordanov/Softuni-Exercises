namespace SumEvensInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    long result = SumEvenNumbers(0, 1000);
                    Console.WriteLine(result);
                }
            }
        }

        private static long SumEvenNumbers(long min, long max)
        {
            return Task.Run(() =>
            {
                long sum = 0;
                for (long i = min; i <= max; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }

                return sum;
            }).Result;
        }
    }
}
