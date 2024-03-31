namespace IteratorDesignPattern.Iterators;

using Contracts;
using Enums;
using Models;

public class NavigationApp : IRouteCollection
{
    private readonly List<Route> _routes;

    public NavigationApp()
    {
        this._routes = new List<Route>();
    }

    public void AddRoute(Route route)
    {
        this._routes.Add(route);
    }

    public IIterator CreateIterator(IteratorType iteratorType)
    {
        return iteratorType switch
        {
            IteratorType.Shortest => new ShortestRouteIterator(this._routes),
            IteratorType.Scenic => new ScenicRouteIterator(this._routes),
            IteratorType.LeastTraffic => new LeastTrafficRouteIterator(this._routes),
            _ => throw new ArgumentException("Invalid iterator type!"),
        };
    }
}