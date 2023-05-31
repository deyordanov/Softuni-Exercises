string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Func<string, bool> predicate = x => char.IsUpper(x[0]);
foreach(string word in words.Where(predicate))
{
    Console.WriteLine(word);
}