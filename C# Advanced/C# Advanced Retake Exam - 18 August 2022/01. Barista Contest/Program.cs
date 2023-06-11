namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                { "Cortado", 0},
                { "Espresso", 0},
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0}
            };

            while(coffee.Any() &&  milk.Any())
            {
                int value = coffee.Peek() + milk.Peek();
                if(value == 50)
                {
                    drinks["Cortado"]++;
                }
                else if(value == 75)
                {
                    drinks["Espresso"]++;
                }
                else if (value ==100)
                {
                    drinks["Capuccino"]++;
                }
                else if (value == 150)
                {
                    drinks["Americano"]++;
                }
                else if (value == 200)
                {
                    drinks["Latte"]++;
                }
                else
                {
                    coffee.Dequeue();
                    int currMilk = milk.Pop() - 5;
                    milk.Push(currMilk);
                    continue;
                }
                coffee.Dequeue();
                milk.Pop();
            }

            if(!milk.Any() && !coffee.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine(coffee.Any() ? $"Coffee left: {string.Join(", ", coffee)}"
                : "Coffee left: none");

            Console.WriteLine(milk.Any() ? $"Milk left: {string.Join(", ", milk)}"
                : "Milk left: none");

            Console.WriteLine(string.Join(Environment.NewLine, drinks.Where(d => d.Value > 0).OrderBy(d => d.Value).ThenByDescending(d => d.Key).Select(d => $"{d.Key}: {d.Value}")));
        }
    }
}