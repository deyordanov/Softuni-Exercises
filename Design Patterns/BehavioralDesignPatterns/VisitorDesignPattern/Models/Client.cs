namespace VisitorDesignPattern.Models;

using Visitors.Contracts;

public abstract class Client
{
    private readonly string _name;
    private readonly string _address;
    private readonly string _number;

    protected Client(
        string name,
        string address,
        string number)
    {
        this._name = name;
        this._address = address;
        this._number = number;
    }

    public abstract void Accept(IVisitor visitor);
}