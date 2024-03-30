namespace ObserverDesignPattern.Listeners;

using Contracts;
using Enums;

public class EmailMessageListener : IListener
{
    private readonly string _email;

    public EmailMessageListener(string email)
    {
        this._email = email;
    }

    public void Update(Event eventType)
    {
        Console.WriteLine($"Send email to {this._email} regarding {eventType}.");
    }
}