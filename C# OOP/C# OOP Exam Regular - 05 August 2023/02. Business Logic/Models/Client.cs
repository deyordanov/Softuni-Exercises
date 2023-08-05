namespace BankLoan.Models;

using System;
using Contracts;
using Utilities.Messages;

public abstract class Client : IClient
{
    private string name;
    private string id;
    private int interest;
    private double income;

    public Client(string name, string id, int interest, double income)
    {
        this.Name = name;
        this.Id = id;
        this.Interest = interest;
        this.Income = income;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
            }

            this.name = value;
        }
    }

    public string Id
    {
        get => this.id;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
            }

            this.id = value;
        }
    }

    public int Interest
    {
        get => this.interest;
        protected set => this.interest = value;
    }

    public double Income
    {
        get =>  this.income;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);
            }

            this.income = value;
        }
    }

    public abstract void IncreaseInterest();
}