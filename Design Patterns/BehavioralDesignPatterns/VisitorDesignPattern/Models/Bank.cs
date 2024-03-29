namespace VisitorDesignPattern.Models;

using Visitors.Contracts;

public class Bank : Client
{
    private readonly int _branchesInsured;
    public Bank(
        string name, 
        string address, 
        string number,
        int branchesInsured) 
        : base(name, address, number)
    {
        this._branchesInsured = branchesInsured;
    }

    public override void Accept(IVisitor visitor)
        => visitor.Visit(this);

}