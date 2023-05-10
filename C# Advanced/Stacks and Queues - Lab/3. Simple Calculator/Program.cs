string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Array.Reverse(tokens);
Stack<string> stack = new Stack<string>(tokens);
int result = int.Parse(stack.Pop());
while(stack.Count > 0)
{
    string symbol = stack.Pop();
    int currentNumber = int.Parse(stack.Pop());
    switch (symbol)
    {
        case "+":
            result += currentNumber;
            break;
        case "-":
            result -= currentNumber;
            break;
    }
}
Console.WriteLine(result);