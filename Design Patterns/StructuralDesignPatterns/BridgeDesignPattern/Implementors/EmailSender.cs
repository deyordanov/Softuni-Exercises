namespace BridgeDesignPattern.Implementors;

using Contracts;

public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}