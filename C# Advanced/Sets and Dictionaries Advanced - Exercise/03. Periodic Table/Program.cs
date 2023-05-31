int n = int.Parse(Console.ReadLine());
HashSet<string> set = new HashSet<string>();
for(int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    foreach(string element in elements)
    {
        set.Add(element);
    }
}
set = set.OrderBy(x => x).ToHashSet();
Console.WriteLine(string.Join(" ", set));