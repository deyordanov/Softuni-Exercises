namespace CommandDesignPattern.Commands;

using Contracts;
using Receivers;

public class ComplexCommand : ICommand
{
    private readonly Receiver _receiver;
    private readonly string _payloadA;
    private readonly string _payloadB;

    public ComplexCommand(
        Receiver receiver,
        string payloadA,
        string payloadB)
    {
        this._receiver = receiver;
        this._payloadA = payloadA;
        this._payloadB = payloadB;
    }

    public void Execute()
    {
        Console.WriteLine("Complex Command: complex actions should be performed through a Receiver object.");
        this._receiver.DoSomething(this._payloadA);
        this._receiver.DoSomethingElse(this._payloadB);
    }
}