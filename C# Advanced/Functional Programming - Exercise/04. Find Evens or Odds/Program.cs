int[] ranges = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<string, int, bool> sort = (condition, number) =>
{
    return condition == "even" ? number % 2 == 0 : number % 2 != 0;
};

Func<int, int, List<int>> range = (start, end) =>
{
    List<int> numbers = new List<int>();
    for(int i = start; i <= end; i++)
    {
        numbers.Add(i);
    }
    return numbers;
};

string condition = Console.ReadLine();
List<int> numbers = range(ranges[0], ranges[1]);
Console.WriteLine(string.Join(" ", numbers.Where(x => sort(condition, x))));
