int n = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();  
for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
    string color = input[0];
    if (!clothes.ContainsKey(input[0]))
    {
        clothes.Add(color, new Dictionary<string, int>());
    }
    for(int j = 1; j < input.Length; j++)
    {
        if (!clothes[color].ContainsKey(input[j]))
        {
            clothes[color].Add(input[j], 0);
        }
        clothes[color][input[j]]++;
    }
}

string[] pieceOfClothing = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);   
foreach(string color in clothes.Keys)
{
    Console.WriteLine($"{color} clothes:");
    foreach (string clothing in clothes[color].Keys)
    {
        string output = color == pieceOfClothing[0] && clothing == pieceOfClothing[1] 
            ? $"* {clothing} - {clothes[color][clothing]} (found!)" 
            : $"* {clothing} - {clothes[color][clothing]}";
        Console.WriteLine(output);
    }
}