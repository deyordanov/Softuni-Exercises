namespace CommandPattern.Core.Commands
{
    using Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
