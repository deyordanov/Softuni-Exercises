int range = int.Parse(Console.ReadLine());
int[] dividors = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Func<int, int[]> numsInRange = range =>
{
    int[] numbers = new int[range];
    for(int i = 1; i <= range; i++)
    {
        numbers[i - 1] = i;
    }
    return numbers;
};

Func<int[], int, bool> filter = (dividors, number) =>
{
    return dividors.All(x => number % x == 0) ? true : false;
};

int[] numbers = numsInRange(range);
Console.WriteLine(string.Join(" ", numbers.Where(x => filter(dividors, x))));