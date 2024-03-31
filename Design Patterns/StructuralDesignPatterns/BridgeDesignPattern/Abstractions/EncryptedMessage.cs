namespace BridgeDesignPattern.Abstractions;

using Implementors.Contracts;

public class EncryptedMessage : Message
{
    public EncryptedMessage(IMessageSender messageSender) 
        : base(messageSender) { }

    public override void Send(string message)
    {
        string encryptedMessage = $"Encrypted ({message})";
        this._messageSender.SendMessage(encryptedMessage);
    }
}