namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> challenges = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            while (tools.Any() && substances.Any() && challenges.Any())
            {
                int result = tools.Peek() * substances.Peek();
                if (challenges.Any(c => c == result))
                {
                    challenges.Remove(result);
                    tools.Dequeue();
                    substances.Pop();
                }
                else
                {
                    int currTool = tools.Dequeue() + 1;
                    tools.Enqueue(currTool);
                    int currSubstance = substances.Pop() - 1;
                    if (currSubstance != 0)
                    {
                        substances.Push(currSubstance);
                    }
                }
            }

            if (challenges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}