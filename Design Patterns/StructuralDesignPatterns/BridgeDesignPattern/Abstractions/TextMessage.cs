namespace BridgeDesignPattern.Abstractions;

using Implementors.Contracts;

public class TextMessage : Message
{
    public TextMessage(IMessageSender messageSender) 
        : base(messageSender) { }

    public override void Send(string message)
    {
        this._messageSender.SendMessage(message);
    }
}