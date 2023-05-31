int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Func<int[], int> sum = Sum;
Func<int[], int> count = Count;
Console.WriteLine(count(numbers));
Console.WriteLine(sum(numbers));
int Sum(int[] numbers)
{
    int sum = 0;
    foreach(int number in numbers)
    {
        sum += number;
    }
    return sum;
}


int Count(int[] numbers)
{
    int count = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
        count++;
    }
    return count;
}