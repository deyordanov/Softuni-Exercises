namespace StrategyDesignPattern.Strategies;

using Contracts;

public class ScenicRouteStrategy : IRoutingStrategy
{
    public void BuildRoute(string start, string destination)
    {
        Console.WriteLine($"Building the most scenic route from {start} to {destination}.");
    }
}