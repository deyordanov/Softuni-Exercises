namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> food = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> peaks = new Dictionary<string, int>()
            {
                { "Vihren", 80 },
                { "Kutelo", 90 },
                { "Banski Suhodol", 100 },
                { "Polezhan", 60 },
                { "Kamenitza", 70 }
            };
            List<string> peaks2 = new List<string>() { "Vihren", "Kutelo", "Banski Suhodol", "Polezhan", "Kamenitza" };

            for(int i = 0; i < peaks2.Count; i+=0)
            {
                if(food.Count == 0 || stamina.Count == 0)
                {
                    break;
                }
                int value = food.Pop() + stamina.Dequeue();
                if(value >= peaks[peaks2[i]])
                {
                    peaks.Remove(peaks2[i]);
                    i++;
                }
            }

            Console.WriteLine(peaks.Count == 0 ? "Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK"
                : "Alex failed! He has to organize his journey better next time -> @PIRINWINS");

            if(peaks.Count() < peaks2.Count())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in peaks2.Where(p => !peaks.ContainsKey(p)))
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}