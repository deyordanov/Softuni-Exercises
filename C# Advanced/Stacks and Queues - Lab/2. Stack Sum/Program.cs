int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> stack = new Stack<int>(numbers);
string end;
while((end = Console.ReadLine().ToLower()) != "end")
{
    string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (input[0])
    {
        case "add":
            stack.Push(int.Parse(input[1]));
            stack.Push(int.Parse(input[2]));
        break;
        case "remove":
            int numberOfElements = int.Parse(input[1]);
            if(stack.Count >= numberOfElements)
                for (int i = 0; i < numberOfElements; i++)
                {
                    stack.Pop();
                }
            break;
    }
}
Console.WriteLine($"Sum: {stack.Sum()}");