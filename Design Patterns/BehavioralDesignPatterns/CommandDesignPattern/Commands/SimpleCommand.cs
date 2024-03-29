namespace CommandDesignPattern.Commands;

using Contracts;

public class SimpleCommand : ICommand
{
    private readonly string? _payload;

    public SimpleCommand(string payload)
    {
        this._payload = payload;
    }

    public void Execute()
    {
        Console.WriteLine($"Simple Command: I can do simple things such as printing: {this._payload ?? string.Empty}");
    }
}