int n = int.Parse(Console.ReadLine());
Stack<int> numbers = new Stack<int>();
for (int i = 0; i < n; i++)
{
    int[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    switch (command[0])
    {
        case 1:
            numbers.Push(command[1]);
            break;
        case 2:
            numbers.Pop();
            break;
        case 3:
            if(numbers.Count > 0) 
                Console.WriteLine(numbers.Max());
            break;
        case 4:
            if (numbers.Count > 0)
                Console.WriteLine(numbers.Min());
            break;
    }
}
Console.WriteLine(string.Join(", ", numbers));