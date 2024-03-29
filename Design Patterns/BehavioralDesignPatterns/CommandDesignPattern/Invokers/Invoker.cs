namespace CommandDesignPattern.Invokers;

using Commands.Contracts;

public class Invoker
{
    private ICommand? _onStartCommand;
    private ICommand? _onEndCommand;

    public void SetOnStartCommand(ICommand command)
    {
        this._onStartCommand = command;
    }

    public void SetOnEndCommand(ICommand command)
    {
        this._onEndCommand = command;
    }

    public void DoSomethingImportant()
    {
        Console.WriteLine($"Invoker: Do something before we begin.");
        if (this._onStartCommand != null)
        {
            this._onStartCommand.Execute();
        }

        Console.WriteLine("Invoker: ...doing something very important...");

        Console.WriteLine($"Invoker: Do something after we are done.");
        if (this._onEndCommand != null)
        {
            this._onEndCommand.Execute();
        }
    }
}