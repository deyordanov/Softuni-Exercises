HashSet<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();
Func<HashSet<int>, int> min = numbers =>
{
    int min = int.MaxValue;
    foreach(int number in numbers)
    {
        if(number < min)
        {
            min = number;
        }
    }
    return min;
};

Console.WriteLine(min(numbers));