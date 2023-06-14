namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> time = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> ducks = new Dictionary<string, int>();
            ducks.Add("Darth Vader Ducky", 0);
            ducks.Add("Thor Ducky", 0);
            ducks.Add("Big Blue Rubber Ducky", 0);
            ducks.Add("Small Yellow Rubber Ducky", 0);
            while(time.Count > 0)
            {
                int currentTime = time.Peek() * tasks.Peek();
                if(currentTime <= 60)
                {
                    ducks["Darth Vader Ducky"]++;
                }
                else if (currentTime >= 61 && currentTime <= 120)
                {
                    ducks["Thor Ducky"]++;
                }
                else if(currentTime >= 121 && currentTime <= 180)
                {
                    ducks["Big Blue Rubber Ducky"]++;
                }
                else if( currentTime >= 181 && currentTime <= 240)
                {
                    ducks["Small Yellow Rubber Ducky"]++;
                }
                else
                {
                    int task = tasks.Pop() - 2;
                    tasks.Push(task);
                    int timeToSwap = time.Dequeue();
                    time.Enqueue(timeToSwap);
                    continue;
                }
                time.Dequeue();
                tasks.Pop();
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine(string.Join(Environment.NewLine, ducks.Select(d => $"{d.Key}: {d.Value}")));
        }
    }
}