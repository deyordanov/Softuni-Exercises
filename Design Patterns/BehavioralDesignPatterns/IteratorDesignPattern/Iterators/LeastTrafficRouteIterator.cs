namespace IteratorDesignPattern.Iterators;

using Contracts;
using Models;

public class LeastTrafficRouteIterator : IIterator
{
    private readonly List<Route> _routes;
    private int _currentIndex = 0;

    public LeastTrafficRouteIterator(List<Route> routes)
    {
        this._routes = routes.OrderBy(r => r.TrafficLevel).ToList();
    }

    public bool HasNext() => this._currentIndex < this._routes.Count;

    public Route Next() => this._routes[_currentIndex++];
}