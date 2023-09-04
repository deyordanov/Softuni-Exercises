namespace DoubleEndedQueue
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoubleEndedQueue<int> queue = new DoubleEndedQueue<int>();
            queue.AddFirst(3);
            queue.AddFirst(1);

            // Console.WriteLine(queue.RemoveFirst());

            queue.AddLast(7);
            queue.AddLast(10);

            // Console.WriteLine(queue.RemoveFirst());
            // Console.WriteLine(queue.RemoveLast());

            Console.WriteLine(queue.Contains(10));
            Console.WriteLine(queue.Contains(290));
            Console.WriteLine(queue.Count);
        }
    }
}