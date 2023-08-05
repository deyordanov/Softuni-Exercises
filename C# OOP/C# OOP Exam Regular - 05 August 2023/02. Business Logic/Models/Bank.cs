namespace BankLoan.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Utilities.Messages;

public abstract class Bank : IBank
{
    private string name;
    private int capacity;
    private List<ILoan> loans;
    private List<IClient> clients;
    public Bank(string name, int capacity)
    {
        this.Name = name;
        this.Capacity = capacity;
        loans = new List<ILoan>();
        clients = new List<IClient>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
            }

            this.name = value;
        }
    }

    public int Capacity
    {
        get => this.capacity;
        private set => this.capacity = value;
    }
    public IReadOnlyCollection<ILoan> Loans => this.loans.AsReadOnly();
    public IReadOnlyCollection<IClient> Clients => this.clients.AsReadOnly();

    public double SumRates()
        => this.loans.Sum(loan => loan.InterestRate);

    public void AddClient(IClient Client)
    {
        if (!(this.Clients.Count() < this.Capacity))
        {
            throw new ArgumentException("Not enough capacity for this client.");
        }

        this.clients.Add(Client);
    }

    public void RemoveClient(IClient Client)
        => this.clients.Remove(Client);

    public void AddLoan(ILoan loan)
        => this.loans.Add(loan);

    public string GetStatistics()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
        string clients = this.Clients.Count == 0 ? "Clients: none" : $"Clients: {string.Join(", ", this.Clients.Select(c => c.Name))}";
        sb.AppendLine(clients);
        sb.AppendLine($"Loans: {this.Loans.Count}, Sum of Rates: {this.SumRates()}");

        return sb.ToString().TrimEnd();
    }
}