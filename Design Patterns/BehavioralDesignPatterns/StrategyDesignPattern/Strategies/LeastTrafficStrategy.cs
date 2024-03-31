namespace StrategyDesignPattern.Strategies;

using Contracts;

public class LeastTrafficStrategy : IRoutingStrategy
{
    public void BuildRoute(string start, string destination)
    {
        Console.WriteLine($"Building the least traffic route from {start} to {destination}.");
    }
}