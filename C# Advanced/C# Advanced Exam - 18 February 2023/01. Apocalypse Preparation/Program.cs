namespace C__Advanced_Exam___18_February_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> items = new Dictionary<string, int>()
            {
                {"Patch", 0 },
                {"Bandage", 0 },
                {"MedKit", 0 }
            };
            while(textiles.Count > 0 && medicaments.Count > 0)
            {
                int value = textiles.Peek() + medicaments.Peek();
                if(value == 30)
                {
                    items["Patch"]++;
                }
                else if(value == 40)
                {
                    items["Bandage"]++;
                }
                else if(value == 100)
                {
                    items["MedKit"]++;
                }
                else if(value > 100)
                {
                    items["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    int newValue = value - 100 + medicaments.Pop();
                    medicaments.Push(newValue);
                    continue;
                }
                else
                {
                    textiles.Dequeue();
                    medicaments.Push(medicaments.Pop() + 10);
                    continue;
                }
                textiles.Dequeue();
                medicaments.Pop();
            }

            if(textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if(textiles.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if(medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }


            foreach(var item in items.Where(i => i.Value > 0).OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if(medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if(textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}