namespace ObserverDesignPattern.Listeners.Contracts;

using Enums;

public interface IListener
{
    void Update(Event eventType);
}