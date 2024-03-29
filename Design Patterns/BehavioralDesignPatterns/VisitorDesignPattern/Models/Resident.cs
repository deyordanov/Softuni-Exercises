namespace VisitorDesignPattern.Models;

using Visitors.Contracts;

public class Resident : Client
{
    private readonly string _insuranceClass;
    public Resident(
        string name, 
        string address, 
        string number,
        string insuranceClass) 
        : base(name, address, number)
    {
        this._insuranceClass = insuranceClass;
    }

    public override void Accept(IVisitor visitor)
        => visitor.Visit(this);
}