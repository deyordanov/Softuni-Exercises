namespace StrategyDesignPattern.Models;

using Strategies.Contracts;

public class NavigationApp
{
    private IRoutingStrategy _routingStrategy;

    public void SetRoutingStrategy(IRoutingStrategy routingStrategy)
    {
        this._routingStrategy = routingStrategy;
    }

    public void Navigate(string start, string destination)
    {
        this._routingStrategy.BuildRoute(start, destination);
    }
}