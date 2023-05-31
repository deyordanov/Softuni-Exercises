int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Func<int[], int[]> reverse = array =>
{
    int[] reversed = new int[array.Length];
    int index = 0;
    for (int i = reversed.Length - 1; i >= 0; i--)
    {
        reversed[index++] = array[i];
    }
    return reversed;
};

Func<int, int, bool> divide = (number, dividor) => number % dividor != 0;

int dividor = int.Parse(Console.ReadLine());
numbers = reverse(numbers);
Console.WriteLine(string.Join(" ", numbers.Where(x => divide(x, dividor))));