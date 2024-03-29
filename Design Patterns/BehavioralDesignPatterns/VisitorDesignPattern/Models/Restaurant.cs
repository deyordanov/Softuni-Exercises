namespace VisitorDesignPattern.Models;

using Visitors.Contracts;

public class Restaurant : Client
{
    private readonly bool _availableAbroad;
    public Restaurant(
        string name, 
        string address, 
        string number,
        bool availableAbroad) 
        : base(name, address, number)
    {
        this._availableAbroad = availableAbroad;
    }

    public override void Accept(IVisitor visitor)
        => visitor.Visit(this);
}