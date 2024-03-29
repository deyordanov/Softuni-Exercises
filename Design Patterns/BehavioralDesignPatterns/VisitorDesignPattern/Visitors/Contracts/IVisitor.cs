namespace VisitorDesignPattern.Visitors.Contracts;

using VisitorDesignPattern.Models;

public interface IVisitor
{
    void Visit(Bank bank);
    void Visit(Company company);
    void Visit(Resident resident);
    void Visit(Restaurant restaurant);
}