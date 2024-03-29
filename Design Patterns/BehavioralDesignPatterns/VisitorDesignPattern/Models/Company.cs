namespace VisitorDesignPattern.Models;

using Visitors.Contracts;

public class Company : Client
{
    private readonly int _numberOfEmployees;

    public Company(
        string name, 
        string address, 
        string number, 
        int numberOfEmployees) 
        : base(name, address, number)
    {
        this._numberOfEmployees = numberOfEmployees;
    }

    public override void Accept(IVisitor visitor)
        => visitor.Visit(this);
}