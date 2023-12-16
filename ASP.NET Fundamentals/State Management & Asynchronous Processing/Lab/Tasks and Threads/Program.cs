namespace Tasks_and_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                PrintAllEvenNumbersInRange(0, 100);
            });

            t1.Start();

            for (int i = 101; i <= 200; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            t1.Join();

            Console.WriteLine("Thread finished work!");
        }

        public static void PrintAllEvenNumbersInRange(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
