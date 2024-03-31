namespace StrategyDesignPattern.Strategies;

using Contracts;

public class ShortestRouteStrategy : IRoutingStrategy
{
    public void BuildRoute(string start, string destination)
    {
        Console.WriteLine($"Build the shortest route from {start} to {destination}.");
    }
}