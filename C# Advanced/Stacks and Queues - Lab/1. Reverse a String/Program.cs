char[] sentence = Console.ReadLine().ToCharArray();
Stack<char> stack = new Stack<char>(sentence);
while(stack.Count > 0)
{
    Console.Write(stack.Pop());
}