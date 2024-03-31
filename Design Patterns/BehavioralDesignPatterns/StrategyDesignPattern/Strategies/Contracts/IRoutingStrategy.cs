namespace StrategyDesignPattern.Strategies.Contracts;

public interface IRoutingStrategy
{
    void BuildRoute(string start, string destination);
}