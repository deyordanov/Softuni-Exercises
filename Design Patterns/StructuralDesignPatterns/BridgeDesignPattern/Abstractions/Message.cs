namespace BridgeDesignPattern.Abstractions;

using Implementors.Contracts;

public abstract class Message
{
    protected IMessageSender _messageSender;

    protected Message(IMessageSender messageSender)
    {
        this._messageSender = messageSender;
    }

    public abstract void Send(string message);
}