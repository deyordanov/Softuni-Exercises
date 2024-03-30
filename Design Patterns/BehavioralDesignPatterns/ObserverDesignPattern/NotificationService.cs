namespace ObserverDesignPattern;

using Enums;
using Listeners.Contracts;

public class NotificationService
{
    private readonly Dictionary<Event, List<IListener>> _customers;

    public NotificationService()
    {
        this._customers = new Dictionary<Event, List<IListener>>();
        foreach(string eventName in Enum.GetNames(typeof(Event)))
        {
            this._customers.Add(Enum.Parse<Event>(eventName), new List<IListener>());
        }
    }

    public void Subscribe(Event eventType, IListener listener)
    {
        this._customers[eventType].Add(listener);
    }

    public void Unsubscribe(Event eventType, IListener listener)
    {
        this._customers[eventType].Remove(listener);
    }

    public void NotifyCustomers(Event eventType)
    {
        foreach (IListener listener in this._customers[eventType])
        {
            listener.Update(eventType);
        }
    }
}