Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
while(songs.Count > 0)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = input[0];
    switch (command)
    {
        case "Play":
            songs.Dequeue();
            break;
        case "Add":
            string song = string.Join(" ", input.Skip(1));
            if (!songs.Contains(song))
            {
                songs.Enqueue(song);
            }
            else
            {
                Console.WriteLine($"{song} is already contained!");
            }
            break;
        case "Show":
            Console.WriteLine(string.Join(", ", songs));
            break;
    }
}
Console.WriteLine("No more songs!");