using PriorityQueue;

namespace StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueImplementation<int> queue = new PriorityQueueImplementation<int>();
            queue.Enqueue(1);
            queue.Enqueue(7);
            queue.Enqueue(3);
            queue.Enqueue(10);
            queue.Enqueue(5);

            // Console.WriteLine(queue.Dequeue());
            // Console.WriteLine(queue.Dequeue());
            // Console.WriteLine(queue.Dequeue());
            // Console.WriteLine(queue.Dequeue());
            // Console.WriteLine(queue.Dequeue());

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.Contains(1));
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Peek());
        }
    }
}