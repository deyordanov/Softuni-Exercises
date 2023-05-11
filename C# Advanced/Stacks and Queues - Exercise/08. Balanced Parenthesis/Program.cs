string parentheses = Console.ReadLine();
Stack<char> stack = new Stack<char>();
for (int i = 0; i < parentheses.Length; i++)
{
    if (parentheses[i] == '(' || parentheses[i] == '[' || parentheses[i] == '{')
    {
        stack.Push(parentheses[i]);
    }
    else
    {
        char opening = stack.Count == 0 ? 'n' : stack.Pop();
        switch (opening)
        {
            case '(':
                Balanced(parentheses[i], ')');
                break;
            case '[':
                Balanced(parentheses[i], ']');
                break;
            case '{':
                Balanced(parentheses[i], '}');
                break;
            default:
                Balanced(parentheses[i], 'n');
                break;
        }
    }
}
Console.WriteLine("YES");

static void Balanced(char currentClosingBracket, char bracket)
{
    if (currentClosingBracket != bracket)
    {
        Console.WriteLine("NO");
        Environment.Exit(0);
    }
}