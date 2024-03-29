namespace VisitorDesignPattern.Visitors;

using Contracts;
using Models;

public class InsuranceMessagingVisitor : IVisitor
{
    public void SendInsuranceEmails(List<Client> clients)
    {
        foreach (Client client in clients)
        {
            client.Accept(this);
        }
    }

    public void Visit(Bank bank)
    {
        Console.WriteLine($"Sending email about theft insurance.");
    }

    public void Visit(Company company)
    {
        Console.WriteLine($"Sending employees and equipment insurance mail.");
    }

    public void Visit(Resident resident)
    {
        Console.WriteLine($"Sending email about medical insurance.");
    }

    public void Visit(Restaurant restaurant)
    {
        Console.WriteLine($"Sending email about fire and food insurance.");
    }
}