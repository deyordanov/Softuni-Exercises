namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            List<string> strings = new List<string> { "asd", "fsd", "fds"};
            stack.AddRange(strings);
            Console.WriteLine(stack.IsEmpty());
        }
    }
}