namespace BridgeDesignPattern.Implementors;

using Contracts;

public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending sms: {message}");
    }
}