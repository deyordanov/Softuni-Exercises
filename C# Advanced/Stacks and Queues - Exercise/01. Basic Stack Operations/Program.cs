int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Stack<int> stack = new Stack<int>();
for(int i = 0; i < input[0]; i++)
{
    stack.Push(numbers[i]);
}
for(int i = 0; i < input[1]; i++)
{
    stack.Pop();
}
Console.WriteLine(Result(stack, input[2]));

static string Result(Stack<int> stack, int numberToFind)
{
    if (stack.Count == 0)
        return "0";

    return stack.Any(x => x == numberToFind) ? "true" : $"{stack.Min()}";
}