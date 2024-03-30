namespace ObserverDesignPattern.Listeners;

using Contracts;
using Enums;

public class MobileAppListener : IListener
{
    private readonly string _username;

    public MobileAppListener(string username)
    {
        this._username = username;
    }


    public void Update(Event eventType)
    {
        Console.WriteLine($"Sending mobile app notification to {this._username} regarding {eventType}.");
    }
}