Func<string, int> parse = x => int.Parse(x);
Func<int, bool> order = x => x % 2 == 0;
int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parse)
    .Where(order)
    .OrderBy(x => x)
    .ToArray();
Console.WriteLine(string.Join(", ", numbers));
